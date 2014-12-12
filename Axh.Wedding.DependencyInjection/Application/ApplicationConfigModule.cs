namespace Axh.Wedding.DependencyInjection.Application
{
    using System.Data.Entity;

    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Wedding.Application.Config;
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.DbInitializers;

    using Ninject.Modules;

    public class ApplicationConfigModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IWeddingConfig>().To<WeddingConfig>().InSingletonScope();
            Bind<IDatabaseInitializer<WeddingContext>>().To<CsvDbInitializer>();
        }
    }
}
