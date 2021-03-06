﻿namespace Axh.Wedding.Application.ViewModelService.Admin
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Axh.Core.Services.Rsvp.Contracts;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.Contracts.Services;
    using Axh.Wedding.Application.Contracts.ViewModelFactories.Admin;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Admin;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Application.ViewModels.Admin;

    using Microsoft.AspNet.Identity;

    public class AdminViewModelService : IAdminViewModelService
    {
        private readonly IAdminViewModelFactory adminViewModelFactory;

        private readonly IWeddingUserService weddingUserService;

        private readonly IPasswordHasher passwordHasher;

        private readonly IRsvpService rsvpService;

        public AdminViewModelService(IAdminViewModelFactory adminViewModelFactory, IWeddingUserService weddingUserService, UserManager<WeddingUser, Guid> userManager, IRsvpService rsvpService)
        {
            this.adminViewModelFactory = adminViewModelFactory;
            this.weddingUserService = weddingUserService;
            this.rsvpService = rsvpService;
            this.passwordHasher = userManager.PasswordHasher;
        }

        public async Task<AdminPageViewModel> GetAdminPageViewModel(UserViewModel user)
        {
            var users = await this.weddingUserService.GetAllWeddingUsersAsync();
            var rsvps = await this.rsvpService.GetAllRsvpsAsync();

            return this.adminViewModelFactory.GetAdminPageViewModel(user, users, rsvps);
        }

        public async Task<EditUserPageViewModel> GetEditUserPageViewModel(UserViewModel user, Guid userId)
        {
            var weddingUser = await this.weddingUserService.FindByIdAsync(userId);

            return this.adminViewModelFactory.GetEditUserPageViewModel(user, weddingUser);
        }

        public async Task<bool> DeleteUser(Guid userId)
        {
            var weddingUser = await this.weddingUserService.FindByIdAsync(userId);

            if (weddingUser == null)
            {
                return false;
            }

            await this.weddingUserService.DeleteAsync(weddingUser);
            return true;
        }

        public async Task<bool> EditUser(EditUserPageViewModel model)
        {
            var weddingUser = await this.weddingUserService.FindByIdAsync(model.UserId);

            if (weddingUser == null)
            {
                return false;
            }

            weddingUser.UserName = model.UserName;

            if (!string.IsNullOrEmpty(model.Password))
            {
                var passwordHash = this.passwordHasher.HashPassword(model.Password);
                await this.weddingUserService.SetPasswordHashAsync(weddingUser, passwordHash);
            }

            await this.EditRole(model.IsAdmin, weddingUser, WeddingRoleNames.Admin);
            await this.EditRole(model.RsvpType == RsvpType.Day, weddingUser, WeddingRoleNames.RsvpDay);
            await this.EditRole(model.RsvpType == RsvpType.Evening, weddingUser, WeddingRoleNames.RsvpEvening);

            await this.weddingUserService.UpdateAsync(weddingUser);
            return true;
        }

        public async Task<AdminRsvpPageViewModel> GetAdminRsvpPageViewModel(UserViewModel user, Guid userId)
        {
            var rsvp = await this.rsvpService.GetRsvpByUserIdAsync(userId);

            return this.adminViewModelFactory.GetAdminRsvpPageViewModel(user, rsvp);
        }

        private async Task<bool> EditRole(bool isInRole, WeddingUser weddingUser, string roleName)
        {
            if (isInRole == await this.weddingUserService.IsInRoleAsync(weddingUser, roleName))
            {
                return true;
            }

            if (isInRole)
            {
                await this.weddingUserService.AddToRoleAsync(weddingUser, roleName);
            }
            else
            {
                await this.weddingUserService.RemoveFromRoleAsync(weddingUser, roleName);
            }

            return true;
        }
    }
}
