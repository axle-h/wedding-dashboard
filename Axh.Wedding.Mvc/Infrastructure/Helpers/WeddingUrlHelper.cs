namespace Axh.Wedding.Mvc.Infrastructure.Helpers
{
    using Axh.Wedding.Application.Contracts.Helpers;

    internal class WeddingUrlHelper : IWeddingUrlHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public WeddingUrlHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        public string HomePageHeader
        {
            get
            {
                return Links.Content.Images.home_bg_jpg;
            }
        }

        public string RsvpPageHeader
        {
            get
            {
                return Links.Content.Images.rsvp_bg_jpg;
            }
        }

        public string InfoPageHeader
        {
            get
            {
                return Links.Content.Images.info_bg_jpg;
            }
        }

        public string ContactPageHeader
        {
            get
            {
                return Links.Content.Images.contact_bg_jpg;
            }
        }
    }
}