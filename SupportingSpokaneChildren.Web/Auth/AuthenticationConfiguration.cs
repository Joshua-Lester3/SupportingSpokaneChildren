using SupportingSpokaneChildren.Data;
using SupportingSpokaneChildren.Data.Auth;
using SupportingSpokaneChildren.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace SupportingSpokaneChildren.Web.Auth;

public static class AuthenticationConfiguration
{
    public static void ConfigureAuthentication(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;

        builder.Services
            .AddIdentity<User, Role>(c =>
            {
                c.ClaimsIdentity.RoleClaimType = AppClaimTypes.Role;
                c.ClaimsIdentity.EmailClaimType = AppClaimTypes.Email;
                c.ClaimsIdentity.UserIdClaimType = AppClaimTypes.UserId;
                c.ClaimsIdentity.UserNameClaimType = AppClaimTypes.UserName;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders()
            .AddClaimsPrincipalFactory<ClaimsPrincipalFactory>();

        builder.Services.AddScoped<SignInService>();

        builder.Services
            .AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = config["Authentication:Google:ClientId"]!;
                options.ClientSecret = config["Authentication:Google:ClientSecret"]!;
                options.ClaimActions.MapJsonKey("pictureUrl", "picture");
                options.Events.OnTicketReceived = async ctx =>
                {
                    await ctx.HttpContext.RequestServices
                        .GetRequiredService<SignInService>()
                        .OnGoogleTicketReceived(ctx);
                };
            })
            .AddMicrosoftAccount(options =>
            {
                options.ClientId = config["Authentication:Microsoft:ClientId"]!;
                options.ClientSecret = config["Authentication:Microsoft:ClientSecret"]!;
                options.SaveTokens = true;

                options.Events.OnTicketReceived = async ctx =>
                {
                    await ctx.HttpContext.RequestServices
                        .GetRequiredService<SignInService>()
                        .OnMicrosoftTicketReceived(ctx);
                };
            })
            ;

        builder.Services.Configure<SecurityStampValidatorOptions>(o =>
        {
            // Configure how often to refresh user claims and validate
            // that the user is still allowed to sign in.
            o.ValidationInterval = TimeSpan.FromMinutes(5);
        });

        builder.Services.ConfigureApplicationCookie(c =>
        {
            c.LoginPath = "/sign-in"; // Razor page "Pages/SignIn.cshtml"

        });
    }

}
