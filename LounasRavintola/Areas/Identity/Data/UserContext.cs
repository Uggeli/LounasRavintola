using LounasRavintola.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LounasRavintola.Data;

public class UserContext : IdentityDbContext<LounasRavintolaUser>
{
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        string ADMIN_ID = "9ac4cd36-3a52-4515-a3fc-416c69f2f69b";
        string ROLE_ID = "a4e67047-6d61-416b-ba5f-8e05a88183cf";

        builder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Name = "admin",
            NormalizedName = "admin".ToUpper(),
            Id = ROLE_ID,
            ConcurrencyStamp = ROLE_ID
        });

        var hasher = new PasswordHasher<LounasRavintolaUser>();

        LounasRavintolaUser lounasRavintolaUser = new LounasRavintolaUser
        {
            Id = ADMIN_ID,
            Email = "kampela@kampela.com",
            NormalizedEmail = "kampela@kampela.com".ToUpper(),
            UserName = "kampela@kampela.com",
            NormalizedUserName = "kampela@kampela.com".ToUpper(),
            EmailConfirmed = true,
            SecurityStamp = string.Empty
        };
        lounasRavintolaUser.PasswordHash = hasher.HashPassword(lounasRavintolaUser, "SalainenSana");

        builder.Entity<LounasRavintolaUser>().HasData(lounasRavintolaUser);

        builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = ROLE_ID,
            UserId = ADMIN_ID
        });


    }
}
