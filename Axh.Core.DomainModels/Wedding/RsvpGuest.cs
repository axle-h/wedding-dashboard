namespace Axh.Core.DomainModels.Wedding
{
    using System;

    public class RsvpGuest
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string Surname { get; set; }

        public bool IsAttending { get; set; }

        public string DietaryRequirements { get; set; }

        public virtual Rsvp Rsvp { get; set; }
    }
}
