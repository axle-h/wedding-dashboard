namespace Axh.Wedding.Application.ViewModelService.Rsvp
{
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public class RsvpViewModelService : IRsvpViewModelService
    {
        private readonly IRsvpViewModelFactory rsvpViewModelFactory;

        public RsvpViewModelService(IRsvpViewModelFactory rsvpViewModelFactory)
        {
            this.rsvpViewModelFactory = rsvpViewModelFactory;
        }

        public RsvpPageViewModel GetRsvpPageViewModel()
        {
            return this.rsvpViewModelFactory.GetRsvpPageViewModel();
        }
    }
}
