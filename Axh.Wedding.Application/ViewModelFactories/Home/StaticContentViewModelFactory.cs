﻿namespace Axh.Wedding.Application.ViewModelFactories.Home
{
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Home;
    using Axh.Wedding.Application.ViewModels.Home;
    using Axh.Wedding.Resources;

    public class StaticContentViewModelFactory : IStaticContentViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        private readonly IWeddingConfig weddingConfig;

        private readonly IAccountViewModelFactory accountViewModelFactory;

        public StaticContentViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper, IWeddingConfig weddingConfig, IAccountViewModelFactory accountViewModelFactory)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
            this.weddingConfig = weddingConfig;
            this.accountViewModelFactory = accountViewModelFactory;
        }

        public HomePageViewModel GetHomePageViewModel(string user)
        {
            return this.pageViewModelFactory.GetPageViewModel<HomePageViewModel>(
                accountViewModelFactory.GetUserViewModel(user),
                weddingUrlHelper.HomePageHeader,
                Resources.HomePage_Link,
                Resources.HomePage_Title,
                null,
                weddingUrlHelper.Rsvp,
                Resources.RsvpPage_Link);
        }

        public InformationPageViewModel GetInformationPageViewModel(string user)
        {
            var viewModel = this.pageViewModelFactory.GetPageViewModel<InformationPageViewModel>(
                accountViewModelFactory.GetUserViewModel(user),
                weddingUrlHelper.InfoPageHeader,
                Resources.InformationPage_Link,
                Resources.InformationPage_Title,
                Resources.InformationPage_SubTitle);

            viewModel.VenueAddress = weddingConfig.VenueAddress;
            viewModel.VenuePhone = weddingConfig.VenuePhone;

            viewModel.HotelAddress = weddingConfig.HotelAddress;
            viewModel.HotelPhone = weddingConfig.HotelPhone;

            return viewModel;
        }

        public ContactPageViewModel GetContactPageViewModel(string user)
        {
            return this.pageViewModelFactory.GetPageViewModel<ContactPageViewModel>(
                accountViewModelFactory.GetUserViewModel(user),
                weddingUrlHelper.ContactPageHeader,
                Resources.ContactPage_Link,
                Resources.ContactPage_Title,
                Resources.ContactPage_SubTitle);
        }
    }
}
