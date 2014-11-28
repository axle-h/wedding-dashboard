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
                       UserRoles = user.UserRoles.Select(GetWeddingUserRole).ToList()
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
                       UserRoles = user.UserRoles.Select(GetUserRole).ToList()
                   };
        }

        public WeddingUserRole GetWeddingUserRole(UserRole role)
        {
            return role == null ? null : new WeddingUserRole { Id = role.Id, RoleName = role.RoleName };
        }

        public UserRole GetUserRole(WeddingUserRole role)
        {
            return role == null ? null : new UserRole { Id = role.Id, RoleName = role.RoleName };
        }
    }
}
