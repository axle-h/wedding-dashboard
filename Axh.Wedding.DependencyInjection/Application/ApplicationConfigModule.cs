namespace Axh.Wedding.DependencyInjection.Application
{
    using Axh.Wedding.Application.Config;
    using Axh.Wedding.Application.Contracts.Config;

    using Ninject.Modules;

    public class ApplicationConfigModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IWeddingConfig>().To<WeddingConfig>().InSingletonScope();
        }
    }
}
