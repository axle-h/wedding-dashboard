namespace Axh.Core.DomainModels.Accounts
{
    using System;

    using Axh.Core.Common;

    public class Guest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public GuestType GuestType { get; set; }

        public virtual User User { get; set; }
    }
}
