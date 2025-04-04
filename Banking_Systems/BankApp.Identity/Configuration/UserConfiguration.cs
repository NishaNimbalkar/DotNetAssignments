using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BankApp.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankApp.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    FirstName = "Admin",
                    LastName = "system",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Admin@123")

                },
                 new ApplicationUser
                 {
                     Id = "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                     Email = "nisha@gmail.com",
                     NormalizedEmail = "VNISHA@GMAIL.COM",
                     FirstName = "nisha",
                     LastName = "Nimbalkar",
                     UserName = "nisha@gmail.com",
                     NormalizedUserName = "NISHA@GMAIL.COM",
                     PasswordHash = hasher.HashPassword(null, "Nisha@123")
                 }


                );
        }
    }
}
