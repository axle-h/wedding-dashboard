namespace Axh.Wedding.Application.Contracts.Config
{
    using System;

    public interface IWeddingConfig
    {
        string Bride { get; }

        string Groom { get; }

        string Venue { get; }

        DateTime Date { get; }

        string VenueAddress { get; }

        string VenuePhone { get; }

        string HotelAddress { get; }

        string HotelPhone { get; }
    }
}