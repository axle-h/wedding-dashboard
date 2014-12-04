namespace Axh.Wedding.Application.DbInitializers
{
    using System;
    using System.Data.Entity;

    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Core.DomainModels.Accounts;
    using Axh.Core.DomainModels.Wedding;
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
            var adminRole = new Role { Id = Guid.Parse("999bc263-9261-48f6-a9e1-400861a72a3c"), RoleName = "admin" };
            var guestRole = new Role { Id = Guid.Parse("83fb4e3c-b065-45b9-892e-91c33a5afb79"), RoleName = "guest" };
            var role = new Role { Id = Guid.Parse("c317ee96-47dc-4f02-9715-ba88924a95cd"), RoleName = "user" };

            context.Roles.Add(adminRole);
            context.Roles.Add(guestRole);
            context.Roles.Add(role);
            context.SaveChanges();

            var adminUser = new User
                            {
                                Id = Guid.Parse("ab8e3677-8bf2-4504-8b13-902413eef61e"),
                                UserName = "admin",
                                Roles = new[] { adminRole },
                                PasswordHash = this.userManager.PasswordHasher.HashPassword("password"),
                                SecurityStamp = Guid.NewGuid().ToString()
                            };

            context.Users.Add(adminUser);
            context.SaveChanges();


            var groomGuest = new Guest { Id = Guid.Parse("f63d39aa-411e-4c33-9d45-bf536c5745ab"), FirstName = "Groom", Surname = "Danger", User = adminUser };
            var brideGuest = new Guest { Id = Guid.Parse("39f40fba-19db-43be-ba4d-a5073c9089a8"), FirstName = "Bride", Surname = "Safe", User = adminUser };
            context.Guests.Add(groomGuest);
            context.Guests.Add(brideGuest);
            context.SaveChanges();
        }
    }
}