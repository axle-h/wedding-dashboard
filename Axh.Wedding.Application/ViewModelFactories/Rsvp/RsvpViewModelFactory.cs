namespace Axh.Wedding.Application.ViewModelFactories.Rsvp
{
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.ViewModels.Rsvp;
    using Axh.Wedding.Resources;

    public class RsvpViewModelFactory : IRsvpViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        public RsvpViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
        }

        public RsvpPageViewModel GetRsvpPageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<RsvpPageViewModel>(weddingUrlHelper.RsvpPageHeader, true, Resources.RsvpPage_Title, Resources.RsvpPage_SubTitle);
        }
    }
}
