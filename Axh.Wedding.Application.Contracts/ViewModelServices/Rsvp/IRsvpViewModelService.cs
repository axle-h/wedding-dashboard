namespace Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp
{
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public interface IRsvpViewModelService
    {
        RsvpPageViewModel GetRsvpPageViewModel(string user);
    }
}