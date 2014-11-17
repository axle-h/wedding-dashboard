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
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.bootstrap_theme_css));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.font_awesome_css));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.Global_less));
            bundles.Add(siteStyleBundle);

            var headJsBundle = new ScriptBundle(HeadJsBundleVirtualPath).Include(VirtualPathUtility.ToAppRelative(Links.Scripts.modernizr_2_8_3_js));
            bundles.Add(headJsBundle);

            var mainBodyJsBundle = new ScriptBundle(MainBodyJsBundleVirtualPath);
		    mainBodyJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.jquery_2_1_1_js));
            mainBodyJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.bootstrap_js));
            bundles.Add(mainBodyJsBundle);
		}
	}
}
