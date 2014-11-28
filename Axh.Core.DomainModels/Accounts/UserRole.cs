namespace Axh.Core.DomainModels.Accounts
{
    using System;
    using System.Collections.Generic;

    public class UserRole
    {
        public Guid Id { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
