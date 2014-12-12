namespace Axh.Wedding.Application.DbInitializers
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    using Axh.Core.Common;
    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Core.DomainModels.Accounts;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.ViewModels.Account;

    using FileHelpers;

    using Microsoft.AspNet.Identity;

    /// <summary>
    /// Initialise db from two csv's:
    /// Users: UserName, Password, IsAdmin, RsvpType
    /// Guests: UserName, FirstName, Surname, GuestType 
    /// </summary>
    public class CsvDbInitializer : DropCreateDatabaseAlways<WeddingContext>
    {
        private const string WeddingUsersResourceName = "Axh.Wedding.Application.DbInitializers.Resources.wedding-users.csv";
        private const string WeddingGuestsResourceName = "Axh.Wedding.Application.DbInitializers.Resources.wedding-guests.csv";

        private readonly IPasswordHasher passwordHasher;

        public CsvDbInitializer(UserManager<WeddingUser, Guid> userManager)
        {
            this.passwordHasher = userManager.PasswordHasher;
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

            IList<User> users;
            IList<Guest> guests;

            var assembly = Assembly.GetExecutingAssembly();

            // Add users
            using (var stream = assembly.GetManifestResourceStream(WeddingUsersResourceName) ?? new MemoryStream())
            using (var reader = new StreamReader(stream))
            {
                users = new FileHelperEngine<CsvUser>().ReadStream(reader).Select(x => GetUser(x, adminRole, rsvpDayRole, rsvpEveningRole)).ToList();
            }
            
            context.Users.AddRange(users);
            context.SaveChanges();

            // Add guests
            using (var stream = assembly.GetManifestResourceStream(WeddingGuestsResourceName) ?? new MemoryStream())
            using (var reader = new StreamReader(stream))
            {
                var csvGuests = new FileHelperEngine<CsvGuest>().ReadStream(reader);
                guests = users.GroupJoin(csvGuests, u => u.UserName, g => g.UserName, (u, grp) => grp.Select(g => GetGuest(u, g))).SelectMany(g => g).ToList();
            }

            context.Guests.AddRange(guests);
            context.SaveChanges();
        }

        private User GetUser(CsvUser csvUser, Role adminRole, Role rsvpDayRole, Role rsvpEveningRole)
        {
            var user = new User { UserName = csvUser.UserName, PasswordHash = this.passwordHasher.HashPassword(csvUser.Password), SecurityStamp = Guid.NewGuid().ToString(), Roles = new List<Role>() };
            if (csvUser.UserName == "admin")
            {
                user.Roles.Add(adminRole);
            }

            switch (csvUser.RsvpType)
            {
                case RsvpType.Day:
                    user.Roles.Add(rsvpDayRole);
                    break;
                case RsvpType.Evening:
                    user.Roles.Add(rsvpEveningRole);
                    break;
            }

            return user;
        }

        private static Guest GetGuest(User user, CsvGuest csvGuest)
        {
            return new Guest { FirstName = csvGuest.FirstName, Surname = csvGuest.Surname, GuestType = csvGuest.GuestType, User = user };
        }

        [DelimitedRecord(",")]
        [IgnoreFirst(1)] 
        private class CsvUser
        {
            [FieldTrim(TrimMode.Both)]
            public string UserName;

            [FieldTrim(TrimMode.Both)]
            public string Password;

            public RsvpType RsvpType;
        }

        [DelimitedRecord(",")]
        [IgnoreFirst(1)] 
        [IgnoreEmptyLines]
        private class CsvGuest
        {
            [FieldTrim(TrimMode.Both)]
            public string UserName;

            [FieldTrim(TrimMode.Both)]
            public string FirstName;

            [FieldTrim(TrimMode.Both)]
            public string Surname;

            public GuestType GuestType;
        }
    }
}
