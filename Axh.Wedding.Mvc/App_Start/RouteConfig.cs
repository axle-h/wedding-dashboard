namespace Axh.Wedding.Mvc
{
    using System.Web.Mvc;
    using System.Web.Routing;

    internal class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("elmah.axd");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = MVC.Home.Name, action = MVC.Home.ActionNames.Index, id = UrlParameter.Optional });
        }
    }
}
