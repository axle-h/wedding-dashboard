namespace Axh.Core.Services.User.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Axh.Core.DomainModels.Accounts;

    public interface IUserService
    {
        Task CreateAsync(User user);

        Task UpdateAsync(User user);

        Task DeleteAsync(User user);

        Task<User> FindByIdAsync(Guid userId);

        Task<User> FindByNameAsync(string userName);

        Task<Role> FindRoleByNameAsync(string roleName);

        Task<User> FindByEmailAsync(string email);

        Task<IList<User>> GetAllUsersAsync();
    }
}