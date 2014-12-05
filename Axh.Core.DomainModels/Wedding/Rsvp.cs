namespace Axh.Core.DomainModels.Wedding
{
    using System;
    using System.Collections.Generic;

    using Axh.Core.DomainModels.Accounts;

    public class Rsvp
    {
        public Guid Id { get; set; }

        public DateTime? RsvpDate { get; set; }

        public virtual ICollection<RsvpGuest> Guests { get; set; }

        public virtual ICollection<RsvpStory> Stories { get; set; }
        
        public virtual User User { get; set; }

    }
}
