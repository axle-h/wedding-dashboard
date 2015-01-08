namespace Axh.Wedding.Application.Factories
{
    using System.Linq;

    using Axh.Core.DomainModels.Accounts;
    using Axh.Wedding.Application.Contracts.Factories;
    using Axh.Wedding.Application.Contracts.Models.Account;

    public class WeddingUserFactory : IWeddingUserFactory
    {
        public WeddingUser GetWeddingUser(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new WeddingUser
                   {
                       Id = user.Id,
                       Email = user.Email,
                       EmailConfirmed = user.EmailConfirmed,
                       PasswordHash = user.PasswordHash,
                       PhoneNumber = user.PhoneNumber,
                       PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                       SecurityStamp = user.SecurityStamp,
                       UserName = user.UserName,
                       Roles = user.Roles.Select(this.GetWeddingRole).ToList(),
                       RsvpDate = user.Rsvp == null ? null : user.Rsvp.RsvpDate,
                       Guests = user.Guests.Select(this.GetWeddingGuest).ToList()
                   };
        }

        public User GetUser(WeddingUser user)
        {
            if (user == null)
            {
                return null;
            }

            return new User
                   {
                       Id = user.Id,
                       Email = user.Email,
                       EmailConfirmed = user.EmailConfirmed,
                       PasswordHash = user.PasswordHash,
                       PhoneNumber = user.PhoneNumber,
                       PhoneNumberConfirmed = user.PhoneNumberConfirmed,
                       SecurityStamp = user.SecurityStamp,
                       UserName = user.UserName,
                       Roles = user.Roles.Select(this.GetRole).ToList(),
                       Guests = user.Guests.Select(this.GetGuest).ToList()
                   };
        }

        public WeddingRole GetWeddingRole(Role role)
        {
            return role == null ? null : new WeddingRole { Id = role.Id, RoleName = role.RoleName };
        }

        public Role GetRole(WeddingRole role)
        {
            return role == null ? null : new Role { Id = role.Id, RoleName = role.RoleName };
        }

        public WeddingGuest GetWeddingGuest(Guest guest)
        {
            return guest == null ? null : new WeddingGuest { Id = guest.Id, FirstName = guest.FirstName, Surname = guest.Surname, GuestType = guest.GuestType };
        }

        public Guest GetGuest(WeddingGuest guest)
        {
            return guest == null ? null : new Guest { Id = guest.Id, FirstName = guest.FirstName, Surname = guest.Surname, GuestType = guest.GuestType };
        }
    }
}
