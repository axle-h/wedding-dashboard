namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp
{
    using System;

    using Axh.Core.DomainModels.Wedding;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public interface IRsvpViewModelFactory
    {
        RsvpPageViewModel GetRsvpPageViewModel(string user, bool isAdmin, Rsvp rsvp);

        RsvpPageViewModel PrepareRsvpPageViewModel(string user, bool isAdmin, RsvpPageViewModel rsvp);

        Rsvp GetRsvp(Guid userId, RsvpPageViewModel rsvp);
    }
}