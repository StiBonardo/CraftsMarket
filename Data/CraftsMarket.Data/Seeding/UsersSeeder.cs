namespace CraftsMarket.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CraftsMarket.Common;
    using CraftsMarket.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class UsersSeeder : ISeeder
    {
        private const string OwnerUsername = "Owner";
        private const string OwnerPassword = "123456";
        private const string OwnerEmail = "s_boyadjiev@abv.bg";
        private const string OwnerPhoneNumber = "+359111111111";

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {

            if (!dbContext.Users.Any(x => x.UserName == OwnerUsername))
            {
                var owner = new ApplicationUser
                {
                    UserName = OwnerUsername,
                    NormalizedUserName = OwnerUsername.ToUpper(),
                    Email = OwnerEmail,
                    NormalizedEmail = OwnerEmail.ToUpper(),
                    EmailConfirmed = true,
                    PhoneNumber = OwnerPhoneNumber,
                    PhoneNumberConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(owner, OwnerPassword);
                owner.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(dbContext);
                await userStore.CreateAsync(owner);

                var ownerRole = dbContext.Roles.First(x => x.Name == GlobalConstants.OwnerRoleName);
                var adminRole = dbContext.Roles.First(x => x.Name == GlobalConstants.AdministratorRoleName);
                dbContext.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = owner.Id,
                    RoleId = ownerRole.Id,
                });
                dbContext.UserRoles.Add(new IdentityUserRole<string>
                {
                    UserId = owner.Id,
                    RoleId = adminRole.Id,
                });

                await dbContext.SaveChangesAsync();
            }
        }
    }
}
