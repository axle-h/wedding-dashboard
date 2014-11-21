namespace Axh.Wedding.Application.ViewModels.Home
{
    using Axh.Wedding.Application.ViewModels.Page;

    public class InformationPageViewModel : PageViewModelBase
    {
        [BindClientProperty("VenueAddress")]
        public string VenueAddress { get; set; }

        public string VenuePhone { get; set; }

        [BindClientProperty("HotelAddress")]
        public string HotelAddress { get; set; }

        public string HotelPhone { get; set; }
    }
}
