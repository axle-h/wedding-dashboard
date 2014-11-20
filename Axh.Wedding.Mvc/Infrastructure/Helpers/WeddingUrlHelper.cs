namespace Axh.Wedding.Mvc.Infrastructure.Helpers
{
    using System.Web.Mvc;

    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.ViewModels.Page;

    internal class WeddingUrlHelper : IWeddingUrlHelper
    {
        private readonly UrlHelper urlHelper;

        public WeddingUrlHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelper = urlHelperFactory.GetUrlHelper();
        }

        public HeaderImageViewModel HomePageHeader
        {
            get
            {
                return new HeaderImageViewModel { Url = Links.Content.Images.home_bg_jpg, IsLight = false, ExtraVerticalMargin = true };
            }
        }

        public HeaderImageViewModel RsvpPageHeader
        {
            get
            {
                return new HeaderImageViewModel { Url = Links.Content.Images.rsvp_bg_jpg, IsLight = true, ExtraVerticalMargin = false };
            }
        }

        public HeaderImageViewModel InfoPageHeader
        {
            get
            {
                return new HeaderImageViewModel { Url = Links.Content.Images.info_bg_jpg, IsLight = true, ExtraVerticalMargin = false };
            }
        }

        public HeaderImageViewModel ContactPageHeader
        {
            get
            {
                return new HeaderImageViewModel { Url = Links.Content.Images.contact_bg_jpg, IsLight = true, ExtraVerticalMargin = false };
            }
        }

        public string Rsvp
        {
            get
            {
                return this.urlHelper.RouteUrl(MVC.Rsvp.Index());
            }
        }
    }
}