namespace Axh.Core.DomainModels.Accounts
{
    using System;

    public class Guest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public virtual User User { get; set; }
    }
}
