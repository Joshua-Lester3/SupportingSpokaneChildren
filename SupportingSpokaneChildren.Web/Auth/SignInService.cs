using SupportingSpokaneChildren.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace SupportingSpokaneChildren.Data.Auth;

public class SignInService(
    AppDbContext db,
    SignInManager<User> signInManager,
    ILogger<SignInService> logger
)
{
    public async Task OnGoogleTicketReceived(TicketReceivedContext ctx)
    {
        var (user, remoteLoginInfo) = await GetOrCreateUser(ctx);
        if (user is null)
        {
            await Forbid(ctx);
            return;
        }


        // Populate or update user photo from Google
        await UpdateUserPhoto(user, ctx.Options.Backchannel,
            () => new HttpRequestMessage(HttpMethod.Get, ctx.Principal!.FindFirstValue("pictureUrl")));

        // OPTIONAL: Populate additional fields on `user` specific to Google, if any.

        await signInManager.UserManager.UpdateAsync(user);

        await SignInExternalUser(ctx, remoteLoginInfo);
    }

    public async Task OnMicrosoftTicketReceived(TicketReceivedContext ctx)
    {
        var (user, remoteLoginInfo) = await GetOrCreateUser(ctx);
        if (user is null)
        {
            await Forbid(ctx);
            return;
        }


        // Populate or update user photo from Microsoft Graph
        await UpdateUserPhoto(user, ctx.Options.Backchannel, () =>
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me/photos/96x96/$value");
            request.Headers.Authorization = new("Bearer", ctx.Properties!.GetTokenValue(OpenIdConnectParameterNames.AccessToken));
            return request;
        });

        // OPTIONAL: Populate additional fields on `user` specific to Microsoft, if any.

        await signInManager.UserManager.UpdateAsync(user);

        await SignInExternalUser(ctx, remoteLoginInfo);
    }

    private static async Task Forbid(TicketReceivedContext ctx, string message = "Forbidden")
    {
        await Results.Text(message, statusCode: StatusCodes.Status403Forbidden).ExecuteAsync(ctx.HttpContext);
        ctx.HandleResponse();
    }

    private async Task<(User? user, UserLoginInfo remoteLoginInfo)> GetOrCreateUser(TicketReceivedContext ctx)
    {
        var remoteProvider = ctx.Scheme.Name;
        var remoteUser = ctx.Principal!;
        var remoteUserId = remoteUser.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var remoteUserEmail = remoteUser.FindFirstValue(ClaimTypes.Email);

        var remoteLoginInfo = new UserLoginInfo(remoteProvider, remoteUserId, ctx.Scheme.DisplayName);

        // Find by the external user ID
        bool foundByLogin = false;
        User? user = await signInManager.UserManager.FindByLoginAsync(remoteProvider, remoteUserId);

        // If not found, look for an existing user by email address
        if (user is not null)
        {
            foundByLogin = true;
        }
        else if (remoteUserEmail is not null)
        {
            user = await signInManager.UserManager.FindByEmailAsync(remoteUserEmail);
            // Don't match existing users by email if the email isn't confirmed.
            if (user?.EmailConfirmed == false) user = null;
        }

        if (user is null)
        {
            if (!await CanUserSignUpAsync(ctx, db, remoteUser))
            {
                return (null, remoteLoginInfo);
            }

            user = new User { UserName = remoteUserEmail };

            // If this user is the first user, give them all roles so there is an initial admin.
            if (!db.Users.Any())
            {
                user.UserRoles = db.Roles.Select(r => new UserRole { Role = r, User = user }).ToList();
            }

            await signInManager.UserManager.CreateAsync(user);
        }

        if (!foundByLogin)
        {
            await signInManager.UserManager.AddLoginAsync(user, remoteLoginInfo);
        }

        user.FullName = remoteUser.FindFirstValue(ClaimTypes.Name) ?? user.FullName;
        if (!string.IsNullOrWhiteSpace(remoteUserEmail))
        {
            user.Email = remoteUserEmail;
            user.EmailConfirmed = true;
        }
        // OPTIONAL: Update any other properties on the user as desired.

        return (user, remoteLoginInfo);
    }



    private async Task UpdateUserPhoto(User user, HttpClient client, Func<HttpRequestMessage> requestFactory)
    {
        UserPhoto? photo = user.Photo = db.UserPhotos.Where(p => p.UserId == user.Id).FirstOrDefault();
        if (photo is not null && photo.ModifiedOn >= DateTimeOffset.Now.AddDays(-7))
        {
            // User photo already populated and reasonably recent.
            return;
        }

        var request = requestFactory();

        if (request.RequestUri is null) return;

        try
        {
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode) return;

            byte[] content = await response.Content.ReadAsByteArrayAsync();

            if (content is not { Length: > 0 }) return;

            if (photo is null)
            {
                user.Photo = photo = new UserPhoto { UserId = user.Id, Content = content };
            }
            else
            {
                photo.Content = content;
                photo.SetTracking(user.Id);
            }
            user.PhotoHash = MD5.HashData(content);
        }
        catch { /* Failure is non-critical */ }
    }

    private Task<bool> CanUserSignUpAsync(TicketReceivedContext ctx, AppDbContext db, ClaimsPrincipal remoteUser)
    {
        // OPTIONAL: Examine the properties of `remoteUser` and determine if they're permitted to sign up.
        return Task.FromResult(true);
    }

    private async Task SignInExternalUser(TicketReceivedContext ctx, UserLoginInfo remoteLoginInfo)
    {
        // ExternalLoginSignInAsync checks that the user isn't locked out.
        var result = await signInManager.ExternalLoginSignInAsync(
            remoteLoginInfo.LoginProvider,
            remoteLoginInfo.ProviderKey,
            isPersistent: true,
            bypassTwoFactor: true);

        if (!result.Succeeded)
        {
            await Forbid(ctx);
            return;
        }

        ctx.HttpContext.Response.Redirect(ctx.ReturnUri ?? "/");
        ctx.HandleResponse();
    }
}
