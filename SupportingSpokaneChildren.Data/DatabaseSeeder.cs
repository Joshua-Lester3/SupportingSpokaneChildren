namespace SupportingSpokaneChildren.Data;

public class DatabaseSeeder(AppDbContext db)
{
    public void Seed()
    {
        SeedRoles();
    }


    private void SeedRoles()
    {
        if (!db.Roles.Any())
        {
            db.Roles.Add(new()
            {
                Permissions = [Permission.UserAdmin],
                Name = Roles.UserAdmin,
                NormalizedName = Roles.UserAdmin.ToUpper(),
            });

            db.Roles.Add(new()
            {
                Permissions = [Permission.Admin],
                Name = Roles.Moderator,
                NormalizedName = Roles.Moderator.ToUpper(),
            });

            // NOTE: In this application's permissions-based authorization system,
            // additional roles can freely be created by administrators.
            // You don't have to seed every possible role.

            db.SaveChanges();
        }
    }
}
