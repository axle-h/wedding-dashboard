namespace Axh.Wedding.DependencyInjection.Application
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.ViewModelFactories.Home;

    using Ninject.Modules;

    public class ApplicationFactoriesModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IHomePageViewModelFactory>().To<HomePageViewModelFactory>();
        }
    }
}
