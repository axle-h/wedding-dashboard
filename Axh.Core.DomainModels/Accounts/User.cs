
namespace Axh.Core.DomainModels.Accounts
{
    using System;
    using System.Collections.Generic;

    using Axh.Core.DomainModels.Wedding;

    public class User
    {

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public virtual ICollection<Guest> Guests { get; set; }

        public virtual Rsvp Rsvp { get; set; }

    }
}
