namespace Axh.Wedding.Mvc
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static readonly string HeadJsBundleVirtualPath = "~/bundles/JsHead-" + MvcApplication.Version + ".js";
        public static readonly string MainBodyJsBundleVirtualPath = "~/bundles/JsBody-" + MvcApplication.Version + ".js";
        public static readonly string SiteCssBundleVirtualPath = "~/bundles/Css-" + MvcApplication.Version + ".css";

        public static void RegisterBundles(BundleCollection bundles)
		{
            var siteStyleBundle = new LessBundle(SiteCssBundleVirtualPath);
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.bootstrap_css));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.font_awesome_css));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.Global_less));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.Account_less));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.Rsvp_less));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.Admin_less));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.Home_less));
            bundles.Add(siteStyleBundle);

            var headJsBundle = new ScriptBundle(HeadJsBundleVirtualPath);
            headJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.jquery_2_1_1_js));
            headJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.modernizr_2_8_3_js));
            headJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.knockout_3_2_0_debug_js));
            bundles.Add(headJsBundle);

            var mainBodyJsBundle = new ScriptBundle(MainBodyJsBundleVirtualPath);
            mainBodyJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.bootstrap_js));
            mainBodyJsBundle.IncludeDirectory(VirtualPathUtility.ToAppRelative(Links.Scripts.ViewModels.Url()), "*.js");
            mainBodyJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.Site_js));
            bundles.Add(mainBodyJsBundle);
		}
	}
}
