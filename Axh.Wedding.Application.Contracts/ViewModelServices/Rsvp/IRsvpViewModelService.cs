namespace Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp
{
    using System;
    using System.Threading.Tasks;

    using Axh.Wedding.Application.ViewModels.Rsvp;

    public interface IRsvpViewModelService
    {
        Task<RsvpPageViewModel> GetRsvpPageViewModel(string user, Guid userId);

        Task<bool> UpdateRsvp(Guid userId, RsvpPageViewModel model);
    }
}