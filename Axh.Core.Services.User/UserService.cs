namespace Axh.Core.Services.User
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axh.Core.DomainModels.Accounts;
    using Axh.Core.Repositories.Wedding.Contracts;
    using Axh.Core.Services.User.Contracts;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        private readonly IRoleRepository roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
        }

        public async Task CreateAsync(User user)
        {
            await this.userRepository.CreateAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await this.userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await this.userRepository.DeleteAsync(user);
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            return await this.userRepository.FindByIdAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await this.userRepository.FindByNameAsync(userName);
        }

        public async Task<Role> FindRoleByNameAsync(string roleName)
        {
            return await this.roleRepository.FindByNameAsync(roleName);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await this.userRepository.FindByEmailAsync(email);
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {
            return await this.userRepository.GetAllAsync();
        }
    }
}
