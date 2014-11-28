namespace Axh.Wedding.Application.DbInitializers
{
    using System;
    using System.Data.Entity;

    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Core.DomainModels.Accounts;
    using Axh.Wedding.Application.Contracts.Models.Account;

    using Microsoft.AspNet.Identity;

    public class DevelopmentDbInitializer : DropCreateDatabaseAlways<WeddingContext>
    {
        private readonly UserManager<WeddingUser, Guid> userManager;

        public DevelopmentDbInitializer(UserManager<WeddingUser, Guid> userManager)
        {
            this.userManager = userManager;
        }

        protected override void Seed(WeddingContext context)
        {
            var adminRole = new UserRole { RoleName = "admin" };
            var guestRole = new UserRole { RoleName = "guest" };
            var userRole = new UserRole { RoleName = "user" };

            context.UserRoles.Add(adminRole);
            context.UserRoles.Add(guestRole);
            context.UserRoles.Add(userRole);
            context.SaveChanges();

            var adminUser = new User
                            {
                                UserName = "admin",
                                UserRoles = new[] { adminRole },
                                PasswordHash = this.userManager.PasswordHasher.HashPassword("password"),
                                SecurityStamp = Guid.NewGuid().ToString()
                            };

            context.Users.Add(adminUser);
            context.SaveChanges();
        }
    }
}