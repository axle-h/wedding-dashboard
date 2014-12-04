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
            var adminRole = new Role { RoleName = "admin" };
            var guestRole = new Role { RoleName = "guest" };
            var role = new Role { RoleName = "user" };

            context.Roles.Add(adminRole);
            context.Roles.Add(guestRole);
            context.Roles.Add(role);
            context.SaveChanges();

            var adminUser = new User
                            {
                                UserName = "admin",
                                Roles = new[] { adminRole },
                                PasswordHash = this.userManager.PasswordHasher.HashPassword("password"),
                                SecurityStamp = Guid.NewGuid().ToString()
                            };

            context.Users.Add(adminUser);
            context.SaveChanges();
        }
    }
}