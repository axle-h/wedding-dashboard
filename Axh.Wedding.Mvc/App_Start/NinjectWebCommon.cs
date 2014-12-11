[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Axh.Wedding.Mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Axh.Wedding.Mvc.App_Start.NinjectWebCommon), "Stop")]

namespace Axh.Wedding.Mvc.App_Start
{
    using System;
    using System.Web;

    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.DependencyInjection.Application;
    using Axh.Wedding.DependencyInjection.Core;
    using Axh.Wedding.Mvc.Infrastructure.Helpers;
    using Axh.Wedding.Mvc.Infrastructure.HttpModule;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Modules;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }


        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public static void RegisterServices(IKernel kernel)
        {
            var modules = new INinjectModule[]
            {
                new MvcApplicationModule(), new ApplicationFactoriesModule(), new ApplicationServicesModule(),
                new ApplicationConfigModule(), new CoreServicesModule(), new CoreContextsModule(), new CoreRepositoriesModule()
            };
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
                this.Bind<IHttpModule>().To<DatabaseInitializerHttpModule>().InSingletonScope();
            }
        }
    }
}