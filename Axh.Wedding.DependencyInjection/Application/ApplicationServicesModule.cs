namespace Axh.Wedding.DependencyInjection.Application
{
    using Axh.Wedding.Application.Contracts.ViewModelServices.Home;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;
    using Axh.Wedding.Application.ViewModelService.Home;
    using Axh.Wedding.Application.ViewModelService.Rsvp;
    using Ninject.Modules;

    public class ApplicationServicesModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IHomePageViewModelService>().To<HomePageViewModelService>();
            Bind<IRsvpViewModelService>().To<RsvpViewModelService>();
        }
    }
}
