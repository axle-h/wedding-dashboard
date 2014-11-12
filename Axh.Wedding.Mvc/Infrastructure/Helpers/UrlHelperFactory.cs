namespace Axh.Wedding.Mvc.Infrastructure.Helpers
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    internal interface IUrlHelperFactory
    {
        UrlHelper GetUrlHelper();
    }

    internal class UrlHelperFactory : IUrlHelperFactory
    {
        public UrlHelper GetUrlHelper()
        {
            var context = new HttpContextWrapper(HttpContext.Current);
            var routeData = RouteTable.Routes.GetRouteData(context);
            return new UrlHelper(new RequestContext(context, routeData));
        }
    }
}