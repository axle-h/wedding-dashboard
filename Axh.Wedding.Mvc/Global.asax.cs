namespace Axh.Wedding.Mvc
{
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using log4net.Config;

    public class MvcApplication : HttpApplication
    {
        internal static string Version = Assembly.GetAssembly(typeof(MvcApplication)).GetName().Version.ToString();

        protected void Application_Start()
        {
            XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
