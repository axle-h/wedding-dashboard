namespace Axh.Wedding.Application.ViewModels.Rsvp
{
    using System;
    using System.Collections.Generic;

    using Axh.Core.Common;
    using Axh.Wedding.Application.ViewModels.Page;

    public class RsvpPageViewModel : PageViewModelBase
    {
        public DateTime? RsvpDate { get; set; }

        [BindClientProperty("Guests")]
        public IEnumerable<GuestViewModel> Guests { get; set; }

        [BindClientProperty("Stories")]
        public IEnumerable<StoryViewModel> Stories { get; set; }

        public IDictionary<RsvpResponse, string> RsvpResponseLabels { get; set; }

        public IDictionary<WeddingPartyMember, string> WeddingPartyMemberLabels { get; set; }

        public IEnumerable<string> StoryTitleLabels { get; set; }
    }
}
