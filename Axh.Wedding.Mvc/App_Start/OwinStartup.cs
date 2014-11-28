using Microsoft.Owin;

[assembly: OwinStartup(typeof(Axh.Wedding.Mvc.App_Start.OwinStartup))]

namespace Axh.Wedding.Mvc.App_Start
{
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security.Cookies;

    using Owin;

    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            var options = new CookieAuthenticationOptions { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString("/account/login") };
            app.UseCookieAuthentication(options);
        }
    }
}
