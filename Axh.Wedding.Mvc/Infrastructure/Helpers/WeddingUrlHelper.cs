namespace Axh.Wedding.Mvc.Infrastructure.Helpers
{
    using Axh.Wedding.Application.Contracts.Helpers;

    internal class WeddingUrlHelper : IWeddingUrlHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public WeddingUrlHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }
    }
}