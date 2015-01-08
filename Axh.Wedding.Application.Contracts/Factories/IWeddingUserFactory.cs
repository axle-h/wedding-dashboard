namespace Axh.Wedding.Application.Contracts.Factories
{
    using Axh.Core.DomainModels.Accounts;
    using Axh.Wedding.Application.Contracts.Models.Account;

    public interface IWeddingUserFactory
    {
        WeddingUser GetWeddingUser(User user);

        User GetUser(WeddingUser user);

        WeddingRole GetWeddingRole(Role role);

        Role GetRole(WeddingRole role);

        WeddingGuest GetWeddingGuest(Guest guest);

        Guest GetGuest(WeddingGuest guest);
    }
}