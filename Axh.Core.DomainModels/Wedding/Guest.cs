namespace Axh.Core.DomainModels.Wedding
{
    using System;

    using Axh.Core.DomainModels.Accounts;

    public class Guest
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public bool? IsAttending { get; set; }

        public virtual User User { get; set; }
    }
}
