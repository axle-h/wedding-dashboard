namespace Axh.Wedding.Application.ViewModelFactories.Rsvp
{
    using System;
    using System.Linq;

    using Axh.Core.DomainModels.Wedding;
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

        public RsvpPageViewModel GetRsvpPageViewModel(string user, Rsvp rsvp)
        {
            if (rsvp == null)
            {
                throw new ArgumentNullException("rsvp");
            }
            
            var model = this.pageViewModelFactory.GetPageViewModel<RsvpPageViewModel>(
                accountViewModelFactory.GetUserViewModel(user),
                weddingUrlHelper.RsvpPageHeader,
                Resources.RsvpPage_Link,
                Resources.RsvpPage_Title,
                Resources.RsvpPage_SubTitle);

            model.RsvpDate = rsvp.RsvpDate;
            model.Guests = rsvp.Guests.Select(GetGuestViewModel);
            model.Stories = rsvp.Stories.Select(GetStoryViewModel);
            return model;
        }

        public Rsvp GetRsvp(Guid userId, RsvpPageViewModel rsvp)
        {
            return new Rsvp
                   {
                       Id = userId,
                       Guests = rsvp.Guests.Select(x => GetGuest(userId, x)).ToList(),
                       Stories = rsvp.Stories.Select(GetStory).ToList(),
                       RsvpDate = rsvp.RsvpDate
                   };
        }

        private static GuestViewModel GetGuestViewModel(Guest guest)
        {
            return new GuestViewModel { Id = guest.Id, FirstName = guest.FirstName, Surname = guest.Surname, IsAttending = guest.IsAttending.GetValueOrDefault() };
        }

        private static Guest GetGuest(Guid userId, GuestViewModel guest)
        {
            return new Guest { Id = guest.Id, FirstName = guest.FirstName, Surname = guest.Surname, IsAttending = guest.IsAttending, UserId = userId };
        }

        private static StoryViewModel GetStoryViewModel(RsvpStory rsvpStory)
        {
            return new StoryViewModel { Id = rsvpStory.Id, StoryBody = rsvpStory.StoryBody, StorySubject = rsvpStory.StorySubject };
        }

        private static RsvpStory GetStory(StoryViewModel rsvpStory)
        {
            return new RsvpStory { Id = rsvpStory.Id, StoryBody = rsvpStory.StoryBody, StorySubject = rsvpStory.StorySubject };
        }
    }
}
