namespace Axh.Wedding.Application.ViewModels.Admin
{
    using System.Collections.Generic;

    using Axh.Core.Common;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Page;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public class AdminRsvpPageViewModel : PageViewModelBase
    {
        public UserViewModel RsvpUser { get; set; }

        public IEnumerable<GuestViewModel> Guests { get; set; }

        public IEnumerable<StoryViewModel> Stories { get; set; }

        public IDictionary<WeddingPartyMember, string> WeddingPartyMemberLabels { get; set; }

        public IDictionary<RsvpResponse, string> RsvpResponseLabels { get; set; }
    }
}
