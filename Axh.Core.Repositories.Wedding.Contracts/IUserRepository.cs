namespace Axh.Core.Repositories.Wedding.Contracts
{
    using System;
    using System.Threading.Tasks;

    using Axh.Core.DomainModels.Accounts;

    public interface IUserRepository : IDisposable
    {
        Task<User> FindByIdAsync(Guid userId);

        Task<bool> CreateAsync(User user);

        Task<bool> UpdateAsync(User user);

        Task<bool> DeleteAsync(User user);

        Task<User> FindByNameAsync(string userName);

        Task<User> FindByEmailAsync(string email);
    }
}