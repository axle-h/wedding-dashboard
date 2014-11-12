namespace Axh.Wedding.DependencyInjection.Application
{
    using Axh.Wedding.Application.Contracts.ViewModelServices.Home;
    using Axh.Wedding.Application.ViewModelService.Home;

    using Ninject.Modules;

    public class ApplicationServicesModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IHomePageViewModelService>().To<HomePageViewModelService>();
        }
    }
}
