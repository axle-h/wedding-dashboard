namespace Axh.Wedding.Application.ViewModels.Rsvp
{
    using System;

    using Axh.Core.Common;

    public class StoryViewModel
    {
        public Guid Id { get; set; }

        public WeddingPartyMember StorySubject { get; set; }

        public string StoryBody { get; set; }
    }
}
