namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp
{
    using System;

    using Axh.Core.DomainModels.Wedding;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public interface IRsvpViewModelFactory
    {
        RsvpPageViewModel GetRsvpPageViewModel(string user, Rsvp rsvp);

        RsvpPageViewModel GetRsvpPageViewModel(string user, RsvpPageViewModel rsvp);

        Rsvp GetRsvp(Guid userId, RsvpPageViewModel rsvp);
    }
}