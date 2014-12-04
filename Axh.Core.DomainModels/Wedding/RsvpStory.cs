namespace Axh.Core.DomainModels.Wedding
{
    using System;

    using Axh.Core.Common;

    public class RsvpStory
    {
        public Guid Id { get; set; }

        public WeddingPartyMember StorySubject { get; set; }

        public string StoryBody { get; set; }

        public virtual Rsvp Rsvp { get; set; }
    }
}
