namespace Axh.Wedding.Application.Contracts.Factories
{
    using Axh.Core.DomainModels.Accounts;
    using Axh.Wedding.Application.Contracts.Models.Account;

    public interface IWeddingUserFactory
    {
        WeddingUser GetWeddingUser(User user);

        User GetUser(WeddingUser user);

        WeddingUserRole GetWeddingUserRole(UserRole role);

        UserRole GetUserRole(WeddingUserRole role);
    }
}