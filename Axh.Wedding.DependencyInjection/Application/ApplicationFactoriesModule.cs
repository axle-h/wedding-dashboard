namespace Axh.Wedding.DependencyInjection.Application
{
    using Axh.Wedding.Application.Contracts.Factories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Admin;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.Factories;
    using Axh.Wedding.Application.ViewModelFactories;
    using Axh.Wedding.Application.ViewModelFactories.Account;
    using Axh.Wedding.Application.ViewModelFactories.Admin;
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
            BindFactories();
            BindViewModelFactories();
        }

        private void BindFactories()
        {
            Bind<IWeddingUserFactory>().To<WeddingUserFactory>();
        }

        private void BindViewModelFactories()
        {
            Bind<IAccountViewModelFactory>().To<AccountViewModelFactory>();
            Bind<IPageViewModelFactory>().To<PageViewModelFactory>();
            Bind<IStaticContentViewModelFactory>().To<StaticContentViewModelFactory>();
            Bind<IRsvpViewModelFactory>().To<RsvpViewModelFactory>();
            Bind<IAdminViewModelFactory>().To<AdminViewModelFactory>();
        }
    }
}
