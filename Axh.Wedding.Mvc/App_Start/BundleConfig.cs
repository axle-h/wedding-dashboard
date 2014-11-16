namespace Axh.Wedding.Mvc
{
    using System.Web;
    using System.Web.Optimization;

    public class BundleConfig
    {
        public static readonly string HeadJsBundleVirtualPath = "~/bundles/JsHead-" + MvcApplication.Version;
        public static readonly string MainBodyJsBundleVirtualPath = "~/bundles/JsBody-" + MvcApplication.Version;
        public static readonly string SiteCssBundleVirtualPath = "~/bundles/Css-" + MvcApplication.Version;
        public static readonly string SiteLessBundleVirtualPath = "~/bundles/Less" + MvcApplication.Version;

        public static void RegisterBundles(BundleCollection bundles)
		{
            var siteStyleBundle = new StyleBundle(SiteCssBundleVirtualPath);
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.bootstrap_css));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.bootstrap_theme_css));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.font_awesome_css));
            siteStyleBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.Site_css));
            bundles.Add(siteStyleBundle);

            var siteLessBundle = new LessBundle(SiteLessBundleVirtualPath);
            siteLessBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.Global_less));
            siteLessBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.variables_less));
            siteLessBundle.Include(VirtualPathUtility.ToAppRelative(Links.Content.SiteLess.mixins_less));
            bundles.Add(siteLessBundle);

            var headJsBundle = new ScriptBundle(HeadJsBundleVirtualPath).Include(VirtualPathUtility.ToAppRelative(Links.Scripts.modernizr_2_8_3_js));
            bundles.Add(headJsBundle);

            var mainBodyJsBundle = new ScriptBundle(MainBodyJsBundleVirtualPath);
		    mainBodyJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.jquery_2_1_1_js));
            mainBodyJsBundle.Include(VirtualPathUtility.ToAppRelative(Links.Scripts.bootstrap_js));
            bundles.Add(mainBodyJsBundle);
		}
	}
}
