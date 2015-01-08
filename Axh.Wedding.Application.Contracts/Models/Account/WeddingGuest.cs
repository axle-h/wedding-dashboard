namespace Axh.Wedding.Application.Contracts.Models.Account
{
    using System;

    using Axh.Core.Common;

    public class WeddingGuest
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public GuestType GuestType { get; set; }
    }
}
