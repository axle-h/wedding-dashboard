namespace Axh.Wedding.Application.ViewModels.Rsvp
{
    using System;

    using Axh.Core.Common;
    using Axh.Wedding.Application.ViewModels.Page;

    public class StoryViewModel
    {
        [BindClientProperty("Id")]
        public Guid? Id { get; set; }

        [BindClientProperty("StorySubject")]
        public WeddingPartyMember StorySubject { get; set; }

        [BindClientProperty("StoryTitle")]
        public string StoryTitle { get; set; }

        [BindClientProperty("StoryBody")]
        public string StoryBody { get; set; }
    }
}
