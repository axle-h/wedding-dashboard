namespace Axh.Wedding.Application.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;

    using Axh.Core.Services.User.Contracts;
    using Axh.Wedding.Application.Contracts.Factories;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.Contracts.Services;

    public class WeddingUserService : IWeddingUserService
    {
        private readonly IUserService userService;

        private readonly IWeddingUserFactory weddingUserFactory;

        public WeddingUserService(IUserService userService, IWeddingUserFactory weddingUserFactory)
        {
            this.userService = userService;
            this.weddingUserFactory = weddingUserFactory;
        }

        public async Task CreateAsync(WeddingUser user)
        {
            await this.userService.CreateAsync(this.weddingUserFactory.GetUser(user));
        }

        public async Task UpdateAsync(WeddingUser user)
        {
            await this.userService.UpdateAsync(this.weddingUserFactory.GetUser(user));
        }

        public async Task DeleteAsync(WeddingUser user)
        {
            await this.userService.DeleteAsync(this.weddingUserFactory.GetUser(user));
        }

        public async Task<WeddingUser> FindByIdAsync(Guid userId)
        {
            var user = await this.userService.FindByIdAsync(userId);
            return this.weddingUserFactory.GetWeddingUser(user);
        }

        public async Task<WeddingUser> FindByNameAsync(string userName)
        {
            var user = await this.userService.FindByNameAsync(userName);
            return this.weddingUserFactory.GetWeddingUser(user);
        }

        public Task SetPasswordHashAsync(WeddingUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        public Task<string> GetPasswordHashAsync(WeddingUser user)
        {
            return Task.FromResult(user == null ? null : user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(WeddingUser user)
        {
            return Task.FromResult(user.PasswordHash != null);
        }

        public Task SetSecurityStampAsync(WeddingUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task<string> GetSecurityStampAsync(WeddingUser user)
        {
            return Task.FromResult(user == null ? null : user.SecurityStamp);
        }

        public async Task AddToRoleAsync(WeddingUser user, string roleName)
        {
            var role = await this.userService.FindRoleByNameAsync(roleName);

            if (role == null)
            {
                return;
            }

            user.Roles.Add(this.weddingUserFactory.GetWeddingRole(role));
        }

        public Task RemoveFromRoleAsync(WeddingUser user, string roleName)
        {
            var role = user.Roles.FirstOrDefault(x => x.RoleName == roleName);

            if (role != null)
            {
                user.Roles.Remove(role);
            }

            return Task.FromResult(0);
        }

        public Task<IList<string>> GetRolesAsync(WeddingUser user)
        {
            return Task.FromResult(user.Roles.Select(x => x.RoleName).ToList() as IList<string>);
        }

        public Task<bool> IsInRoleAsync(WeddingUser user, string roleName)
        {
            return Task.FromResult(user.Roles.FirstOrDefault(x => x.RoleName == roleName) != null);
        }

        public Task SetEmailAsync(WeddingUser user, string email)
        {
            user.Email = email;
            return Task.FromResult(0);
        }

        public Task<string> GetEmailAsync(WeddingUser user)
        {
            return Task.FromResult(user == null ? null : user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(WeddingUser user)
        {
            return Task.FromResult(user != null && user.EmailConfirmed);
        }

        public Task SetEmailConfirmedAsync(WeddingUser user, bool confirmed)
        {
            user.EmailConfirmed = true;
            return Task.FromResult(0);
        }

        public async Task<WeddingUser> FindByEmailAsync(string email)
        {
            var user = await this.userService.FindByEmailAsync(email);
            return this.weddingUserFactory.GetWeddingUser(user);
        }

        public Task SetPhoneNumberAsync(WeddingUser user, string phoneNumber)
        {
            user.PhoneNumber = phoneNumber;
            return Task.FromResult(0);
        }

        public Task<string> GetPhoneNumberAsync(WeddingUser user)
        {
            return Task.FromResult(user == null ? null : user.PhoneNumber);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(WeddingUser user)
        {
            return Task.FromResult(user != null && user.PhoneNumberConfirmed);
        }

        public Task SetPhoneNumberConfirmedAsync(WeddingUser user, bool confirmed)
        {
            user.PhoneNumberConfirmed = confirmed;
            return Task.FromResult(0);
        }

        public async Task<IEnumerable<WeddingUser>> GetAllWeddingUsersAsync()
        {
            var users = await this.userService.GetAllUsersAsync();
            return users.Select(this.weddingUserFactory.GetWeddingUser);
        }

        public void Dispose()
        {
            // Do nothing.
        }
    }
}
