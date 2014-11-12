namespace Axh.Wedding.Mvc
{
    using System.Reflection;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Ninject;
    using Ninject.Web.Common;

    public class MvcApplication : NinjectHttpApplication
    {
        internal static string Version = Assembly.GetAssembly(typeof(MvcApplication)).GetName().Version.ToString();

        /// <summary>
        /// Called when the application is started.
        /// </summary>
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>
        /// The created kernel.
        /// </returns>
        protected override IKernel CreateKernel()
        {
            return DependencyInjection.CreateKernel();
        }
    }
}
