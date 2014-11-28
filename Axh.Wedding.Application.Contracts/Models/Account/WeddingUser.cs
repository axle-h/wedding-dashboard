namespace Axh.Wedding.Application.Contracts.Models.Account
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNet.Identity;

    public class WeddingUser : IUser<Guid>
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public ICollection<WeddingUserRole> UserRoles { get; set; }
    }
}
