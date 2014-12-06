namespace Axh.Wedding.Application.Contracts.Config
{
    using System;

    public interface IWeddingConfig
    {
        bool RunDatabaseInitializer { get; }

        bool AllowAddingGuests { get; }

        string Venue { get; }

        DateTime Date { get; }

        string VenueAddress { get; }

        string VenuePhone { get; }

        string HotelAddress { get; }

        string HotelPhone { get; }

        string Email { get; }

        string Facebook { get; }

        string GitHub { get; }

        string GooglePlus { get; }

        string LinkedIn { get; }

        string Twitter { get; }

        string BrideEmail { get; }

        string BrideFacebook { get; }
    }
}