namespace Axh.Wedding.Application.Contracts.Services
{
    using System;

    using Axh.Wedding.Application.Contracts.Models.Account;

    using Microsoft.AspNet.Identity;

    public interface IWeddingUserService : IUserPasswordStore<WeddingUser, Guid>,
        IUserSecurityStampStore<WeddingUser, Guid>,
        IUserRoleStore<WeddingUser, Guid>,
        IUserEmailStore<WeddingUser, Guid>,
        IUserPhoneNumberStore<WeddingUser, Guid>
    {

    }
}