namespace Axh.Wedding.Application.Contracts.Helpers
{
    using Axh.Wedding.Application.ViewModels.Page;

    public interface IWeddingUrlHelper
    {
        HeaderImageViewModel HomePageHeader { get; }

        HeaderImageViewModel RsvpPageHeader { get; }

        HeaderImageViewModel InfoPageHeader { get; }

        HeaderImageViewModel ContactPageHeader { get; }

        string Rsvp { get; }

        HeaderImageViewModel LoginPageHeader { get; }
    }
}
