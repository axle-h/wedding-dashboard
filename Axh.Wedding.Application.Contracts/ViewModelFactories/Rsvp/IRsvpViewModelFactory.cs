namespace Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp
{
    using System;

    using Axh.Core.Common;
    using Axh.Core.DomainModels.Wedding;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    public interface IRsvpViewModelFactory
    {
        RsvpPageViewModel GetRsvpPageViewModel(UserViewModel user, Rsvp rsvp);

        RsvpPageViewModel PrepareRsvpPageViewModel(UserViewModel user, RsvpPageViewModel rsvp);

        Rsvp GetRsvp(Guid userId, RsvpPageViewModel rsvp);
    }
}