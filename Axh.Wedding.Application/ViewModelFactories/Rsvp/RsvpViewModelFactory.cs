namespace Axh.Wedding.Application.ViewModelFactories.Rsvp
{
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Account;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.ViewModels.Rsvp;
    using Axh.Wedding.Resources;

    public class RsvpViewModelFactory : IRsvpViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        private readonly IAccountViewModelFactory accountViewModelFactory;

        public RsvpViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper, IAccountViewModelFactory accountViewModelFactory)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
            this.accountViewModelFactory = accountViewModelFactory;
        }

        public RsvpPageViewModel GetRsvpPageViewModel(string user)
        {
            return this.pageViewModelFactory.GetPageViewModel<RsvpPageViewModel>(accountViewModelFactory.GetUserViewModel(user), weddingUrlHelper.RsvpPageHeader, Resources.RsvpPage_Link, Resources.RsvpPage_Title, Resources.RsvpPage_SubTitle);
        }
    }
}
