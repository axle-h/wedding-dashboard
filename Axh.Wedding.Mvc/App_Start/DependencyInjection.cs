namespace Axh.Wedding.Mvc
{
    using System;
    using System.Web;

    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.DependencyInjection.Application;
    using Axh.Wedding.Mvc.Infrastructure.Helpers;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;

    internal static class DependencyInjection
    {
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            var modules = new INinjectModule[] { new MvcApplicationModule(), new ApplicationFactoriesModule(), new ApplicationServicesModule() };
            kernel.Load(modules);
        }

        private class MvcApplicationModule : NinjectModule
        {
            /// <summary>
            /// Loads the module into the kernel.
            /// </summary>
            public override void Load()
            {
                this.Bind<IUrlHelperFactory>().To<UrlHelperFactory>();
                this.Bind<IWeddingUrlHelper>().To<WeddingUrlHelper>();
            }
        }
    }
}