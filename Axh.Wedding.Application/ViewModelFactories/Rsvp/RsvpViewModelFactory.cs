﻿namespace Axh.Wedding.Application.ViewModelFactories.Rsvp
{
    using System;
    using System.Linq;

    using Axh.Core.Common;
    using Axh.Core.DomainModels.Wedding;
    using Axh.Wedding.Application.Contracts.Config;
    using Axh.Wedding.Application.Contracts.Helpers;
    using Axh.Wedding.Application.Contracts.ViewModelFactories;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Rsvp;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Rsvp;
    using Axh.Wedding.Resources;

    public class RsvpViewModelFactory : IRsvpViewModelFactory
    {
        private readonly IPageViewModelFactory pageViewModelFactory;

        private readonly IWeddingUrlHelper weddingUrlHelper;

        private readonly IWeddingConfig weddingConfig;

        public RsvpViewModelFactory(IPageViewModelFactory pageViewModelFactory, IWeddingUrlHelper weddingUrlHelper, IWeddingConfig weddingConfig)
        {
            this.pageViewModelFactory = pageViewModelFactory;
            this.weddingUrlHelper = weddingUrlHelper;
            this.weddingConfig = weddingConfig;
        }

        public RsvpPageViewModel GetRsvpPageViewModel(UserViewModel user, Rsvp rsvp)
        {
            if (rsvp == null)
            {
                throw new ArgumentNullException("rsvp");
            }
            
            var model = new RsvpPageViewModel
            {
                RsvpDate = rsvp.RsvpDate,
                Guests = rsvp.Guests.Select(GetGuestViewModel),
                Stories = rsvp.Stories.Select(GetStoryViewModel)
            };

            return this.PrepareRsvpPageViewModel(user, model);
        }

        public Rsvp GetRsvp(Guid userId, RsvpPageViewModel rsvp)
        {
            var guests = rsvp.Guests ?? Enumerable.Empty<GuestViewModel>();
            var stories = rsvp.Stories ?? Enumerable.Empty<StoryViewModel>();

            return new Rsvp
                   {
                       Id = userId,
                       Guests = guests.Select(GetGuest).ToList(),
                       Stories = stories.Select(GetStory).ToList(),
                       RsvpDate = rsvp.RsvpDate
                   };
        }

        public RsvpPageViewModel PrepareRsvpPageViewModel(UserViewModel user, RsvpPageViewModel rsvp)
        {
            var model = this.pageViewModelFactory.PreparePageViewModel(
                rsvp,
                user,
                weddingUrlHelper.RsvpPageHeader,
                Resources.RsvpPage_Link,
                Resources.RsvpPage_Title,
                Resources.RsvpPage_SubTitle);

            model.AllowAddingGuests = this.weddingConfig.AllowAddingGuests;
            model.RsvpResponseLabels = Enum.GetValues(typeof(RsvpResponse)).Cast<RsvpResponse>().ToDictionary(x => x, GetRsvpResponseLabel);
            model.WeddingPartyMemberLabels = Enum.GetValues(typeof(WeddingPartyMember)).Cast<WeddingPartyMember>().ToDictionary(x => x, GetWeddingPartyMemberLabel);

            var random = new Random();
            model.StoryTitleLabels = new[]
            {
                Resources.RandomStoryTitleLabels_0, Resources.RandomStoryTitleLabels_1,
                Resources.RandomStoryTitleLabels_2, Resources.RandomStoryTitleLabels_3,
                Resources.RandomStoryTitleLabels_4, Resources.RandomStoryTitleLabels_5
            }
                .OrderBy(x => random.Next());

            return model;
        }

        private static string GetRsvpResponseLabel(RsvpResponse rsvpResponse)
        {
            switch (rsvpResponse)
            {
                case RsvpResponse.Yes:
                    return Resources.RsvpResponse_Yes;
                case RsvpResponse.No:
                    return Resources.RsvpResponse_No;
                default:
                    throw new ArgumentOutOfRangeException("rsvpResponse");
            }
        }

        private static string GetWeddingPartyMemberLabel(WeddingPartyMember weddingPartyMember)
        {
            switch (weddingPartyMember)
            {
                case WeddingPartyMember.Bride:
                    return Resources.WeddingPartyMember_Bride;
                case WeddingPartyMember.Groom:
                    return Resources.WeddingPartyMember_Groom;
                case WeddingPartyMember.BestMan:
                    return string.Format("{0} ({1})", Resources.WeddingPartyMember_BestMan, Resources.BestMan);
                case WeddingPartyMember.Bridesmaids:
                    return Resources.WeddingPartyMember_Bridesmaids;
                case WeddingPartyMember.Ushers:
                    return Resources.WeddingPartyMember_Ushers;
                case WeddingPartyMember.FatherOfTheBride:
                    return string.Format("{0} ({1}'s {2})", Resources.WeddingPartyMember_FatherOfTheBride, Resources.WeddingPartyMember_Bride, Resources.Dad);
                case WeddingPartyMember.MotherOfTheBride:
                    return string.Format("{0} ({1}'s {2})", Resources.WeddingPartyMember_MotherOfTheBride, Resources.WeddingPartyMember_Bride, Resources.Mum);
                case WeddingPartyMember.FatherOfTheGroom:
                    return string.Format("{0} ({1}'s {2})", Resources.WeddingPartyMember_FatherOfTheGroom, Resources.WeddingPartyMember_Groom, Resources.Dad);
                case WeddingPartyMember.MotherOfTheGroom:
                    return string.Format("{0} ({1}'s {2})", Resources.WeddingPartyMember_MotherOfTheGroom, Resources.WeddingPartyMember_Groom, Resources.Mum);
                default:
                    throw new ArgumentOutOfRangeException("weddingPartyMember");
            }
        }

        private static GuestViewModel GetGuestViewModel(RsvpGuest guest)
        {
            if (guest == null)
            {
                return null;
            }

            return new GuestViewModel
                   {
                       Id = guest.Id,
                       FirstName = guest.FirstName,
                       Surname = guest.Surname,
                       IsAttending = guest.IsAttending ? RsvpResponse.Yes : RsvpResponse.No,
                       DietaryRequirements = guest.DietaryRequirements,
                       GuestType = guest.GuestType
                   };
        }

        private static StoryViewModel GetStoryViewModel(RsvpStory rsvpStory)
        {
            return rsvpStory == null ? null : new StoryViewModel { Id = rsvpStory.Id, StoryTitle = rsvpStory.StoryTitle, StoryBody = rsvpStory.StoryBody, StorySubject = rsvpStory.StorySubject };
        }

        private static RsvpGuest GetGuest(GuestViewModel guest)
        {
            return new RsvpGuest
            {
                Id = guest.Id ?? Guid.NewGuid(),
                FirstName = guest.FirstName,
                Surname = guest.Surname,
                IsAttending = guest.IsAttending == RsvpResponse.Yes,
                DietaryRequirements = guest.DietaryRequirements,
                GuestType = guest.GuestType
            };
        }

        private static RsvpStory GetStory(StoryViewModel rsvpStory)
        {
            return new RsvpStory { Id = rsvpStory.Id ?? Guid.NewGuid(), StoryTitle = rsvpStory.StoryTitle, StoryBody = rsvpStory.StoryBody, StorySubject = rsvpStory.StorySubject };
        }
    }
}
