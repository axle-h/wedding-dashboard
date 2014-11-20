namespace Axh.Wedding.Application.ViewModels.Home
{
    using Axh.Wedding.Application.ViewModels.Page;

    public class InformationPageViewModel : PageViewModelBase
    {
        [BindClientProperty("GoogleMapsPlace")]
        public string VenueAddress { get; set; }

        public string VenuePhone { get; set; }
    }
}
