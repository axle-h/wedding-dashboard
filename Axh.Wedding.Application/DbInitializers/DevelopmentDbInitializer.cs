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
            var adminRole = new Role { RoleName = "admin" };
            var rsvpRole = new Role { RoleName = "rsvp" };

            context.Roles.Add(adminRole);
            context.Roles.Add(rsvpRole);
            context.SaveChanges();

            var adminUser = new User
                            {
                                UserName = "admin",
                                Roles = new[] { adminRole, rsvpRole },
                                PasswordHash = this.userManager.PasswordHasher.HashPassword("password"),
                                SecurityStamp = Guid.NewGuid().ToString()
                            };

            var guestUser = new User
                            {
                                UserName = "guest",
                                Roles = new[] { rsvpRole },
                                PasswordHash = this.userManager.PasswordHasher.HashPassword("password"),
                                SecurityStamp = Guid.NewGuid().ToString()
                            };

            context.Users.Add(adminUser);
            context.Users.Add(guestUser);
            context.SaveChanges();


            var groomGuest = new Guest { FirstName = "Groom", Surname = "Danger", User = adminUser };
            var brideGuest = new Guest { FirstName = "Bride", Surname = "Safe", User = adminUser };

            var fakeGuest1 = new Guest { FirstName = "Fake", Surname = "Guest1", User = guestUser };
            var fakeGuest2 = new Guest { FirstName = "Fake", Surname = "Guest2", User = guestUser };

            context.Guests.Add(fakeGuest1);
            context.Guests.Add(fakeGuest2);
            context.Guests.Add(groomGuest);
            context.Guests.Add(brideGuest);
            context.SaveChanges();
        }
    }
}