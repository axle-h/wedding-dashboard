namespace Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp
{
    using System.Threading.Tasks;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public interface IRsvpViewModelService
    {
        Task<RsvpPageViewModel> GetRsvpPageViewModel(UserViewModel user);

        RsvpPageViewModel GetRsvpPageViewModel(UserViewModel user, RsvpPageViewModel model);

        Task<bool> UpdateRsvp(UserViewModel user, RsvpPageViewModel model);
    }
}