namespace Axh.Wedding.Application.Config
{
    using System.Configuration;

    using Axh.Wedding.Application.Contracts.Config;

    public class WeddingConfig : IWeddingConfig
    {
        public WeddingConfig()
        {
            this.RunDatabaseInitializer = bool.Parse(ConfigurationManager.AppSettings["RunDatabaseInitializer"]);
            this.VenueAddress = ConfigurationManager.AppSettings["Venue_Address"];
            this.VenuePhone = ConfigurationManager.AppSettings["Venue_Phone"];
            this.HotelAddress = ConfigurationManager.AppSettings["Hotel_Address"];
            this.HotelPhone = ConfigurationManager.AppSettings["Hotel_Phone"];

            this.Email = ConfigurationManager.AppSettings["Email"];
            this.Facebook = ConfigurationManager.AppSettings["Facebook"];
            this.GitHub = ConfigurationManager.AppSettings["GitHub"];
            this.GooglePlus = ConfigurationManager.AppSettings["GooglePlus"];
            this.LinkedIn = ConfigurationManager.AppSettings["LinkedIn"];
            this.Twitter = ConfigurationManager.AppSettings["Twitter"];

            this.BrideEmail = ConfigurationManager.AppSettings["Bride_Email"];
            this.BrideFacebook = ConfigurationManager.AppSettings["Bride_Facebook"];

            this.AllowAddingGuests = bool.Parse(ConfigurationManager.AppSettings["AllowAddingGuests"]);
        }

        public bool RunDatabaseInitializer { get; private set; }

        public bool AllowAddingGuests { get; private set; }

        public string VenueAddress { get; private set; }

        public string VenuePhone { get; private set; }

        public string HotelAddress { get; private set; }

        public string HotelPhone { get; private set; }

        public string Email { get; private set; }

        public string Facebook { get; private set; }

        public string GitHub { get; private set; }

        public string GooglePlus { get; private set; }

        public string LinkedIn { get; private set; }

        public string Twitter { get; private set; }

        public string BrideEmail { get; private set; }

        public string BrideFacebook { get; private set; }
    }
}
