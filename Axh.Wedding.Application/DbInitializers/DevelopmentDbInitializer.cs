namespace Axh.Wedding.Application.DbInitializers
{
    using System;
    using System.Data.Entity;

    using Axh.Core.Common;
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
            var adminRole = new Role { RoleName = WeddingRoleNames.Admin };
            var rsvpDayRole = new Role { RoleName = WeddingRoleNames.RsvpDay };
            var rsvpEveningRole = new Role { RoleName = WeddingRoleNames.RsvpEvening };

            context.Roles.Add(adminRole);
            context.Roles.Add(rsvpDayRole);
            context.Roles.Add(rsvpEveningRole);
            context.SaveChanges();

            var adminUser = new User
                            {
                                UserName = "admin",
                                Roles = new[] { adminRole, rsvpDayRole },
                                PasswordHash = this.userManager.PasswordHasher.HashPassword("password"),
                                SecurityStamp = Guid.NewGuid().ToString()
                            };

            var guestUser = new User
                            {
                                UserName = "guest",
                                Roles = new[] { rsvpEveningRole },
                                PasswordHash = this.userManager.PasswordHasher.HashPassword("password"),
                                SecurityStamp = Guid.NewGuid().ToString()
                            };

            context.Users.Add(adminUser);
            context.Users.Add(guestUser);
            context.SaveChanges();


            var groomGuest = new Guest { FirstName = "Groom", Surname = "Danger", User = adminUser, GuestType = GuestType.Adult };
            var brideGuest = new Guest { FirstName = "Bride", Surname = "Safe", User = adminUser, GuestType = GuestType.Adult };

            var fakeGuest1 = new Guest { FirstName = "Fake", Surname = "Guest1", User = guestUser, GuestType = GuestType.Adult };
            var fakeGuest2 = new Guest { FirstName = "Fake", Surname = "Guest2", User = guestUser, GuestType = GuestType.Child };

            context.Guests.Add(fakeGuest1);
            context.Guests.Add(fakeGuest2);
            context.Guests.Add(groomGuest);
            context.Guests.Add(brideGuest);
            context.SaveChanges();
        }
    }
}