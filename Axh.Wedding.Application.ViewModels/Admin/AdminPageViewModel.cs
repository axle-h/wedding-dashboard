namespace Axh.Wedding.Application.ViewModels.Admin
{
    using System.Collections.Generic;
    using System.Linq;

    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Page;

    public class AdminPageViewModel : PageViewModelBase
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public IDictionary<RsvpType, int> Invited { get; set; }

        public int TotalInvited
        {
            get
            {
                return Invited.Values.Sum();
            }
        }

        public IDictionary<RsvpType, int> Attending { get; set; }

        public int TotalAttending
        {
            get
            {
                return Attending.Values.Sum();
            }
        }

        public IDictionary<RsvpType, int> NotAttending { get; set; }

        public int TotalNotAttending
        {
            get
            {
                return NotAttending.Values.Sum();
            }
        }

        public IDictionary<RsvpType, int> Responded { get; set; }

        public int TotalResponded
        {
            get
            {
                return Responded.Values.Sum();
            }
        }
    }
}
