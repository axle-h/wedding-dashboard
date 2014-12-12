namespace Axh.Wedding.DependencyInjection.Application
{
    using System;

    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.Contracts.Services;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Account;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Admin;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Home;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;
    using Axh.Wedding.Application.Services;
    using Axh.Wedding.Application.ViewModelService.Account;
    using Axh.Wedding.Application.ViewModelService.Admin;
    using Axh.Wedding.Application.ViewModelService.Home;
    using Axh.Wedding.Application.ViewModelService.Rsvp;

    using Microsoft.AspNet.Identity;

    using Ninject.Modules;

    public class ApplicationServicesModule : NinjectModule
    {
        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            BindServices();
            BindViewModelServices();
        }

        private void BindServices()
        {
            Bind<IWeddingUserService>().To<WeddingUserService>();

            Bind<IUserStore<WeddingUser, Guid>>().To<WeddingUserService>();
            Bind<IUserRoleStore<WeddingUser, Guid>>().To<WeddingUserService>();
            Bind<UserManager<WeddingUser, Guid>>().ToSelf();
        }

        private void BindViewModelServices()
        {
            Bind<IAccountViewModelService>().To<AccountViewModelService>();
            Bind<IHomePageViewModelService>().To<HomePageViewModelService>();
            Bind<IRsvpViewModelService>().To<RsvpViewModelService>();
            Bind<IAdminViewModelService>().To<AdminViewModelService>();
        }
    }
}
