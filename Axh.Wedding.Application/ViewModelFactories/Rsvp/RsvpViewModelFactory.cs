namespace Axh.Wedding.Application.ViewModelFactories.Rsvp
{
    using Axh.Wedding.Application.Contracts;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.ViewModels.Rsvp;
    using Axh.Wedding.Resources;

    public class RsvpViewModelFactory : IRsvpViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        public RsvpViewModelFactory(IPageViewModelFactory pageViewModelFactory)
        {
            this.pageViewModelFactory = pageViewModelFactory;
        }

        public RsvpPageViewModel GetRsvpPageViewModel()
        {
            return this.pageViewModelFactory.GetPageViewModel<RsvpPageViewModel>(Resources.RsvpPage_Title);
        }
    }
}
