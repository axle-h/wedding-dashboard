namespace Axh.Wedding.DependencyInjection.Application
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.ViewModelFactories;
    using Axh.Wedding.Application.ViewModelFactories.Home;
    using Axh.Wedding.Application.ViewModelFactories.Rsvp;

    using Ninject.Modules;

    public class ApplicationFactoriesModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            this.Bind<IPageViewModelFactory>().To<PageViewModelFactory>();
            this.Bind<IStaticContentViewModelFactory>().To<StaticContentViewModelFactory>();
            this.Bind<IRsvpViewModelFactory>().To<RsvpViewModelFactory>();
        }
    }
}
