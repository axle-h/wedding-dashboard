namespace Axh.Wedding.Application.ViewModels.Home
{
    using System.Collections.Generic;
    using Axh.Wedding.Application.ViewModels.Page;

    public class ContactPageViewModel : PageViewModelBase
    {
        public IEnumerable<SocialCircleViewModel> BrideSocialCircles { get; set; }

        public IEnumerable<SocialCircleViewModel> GroomSocialCircles { get; set; }
    }
}
