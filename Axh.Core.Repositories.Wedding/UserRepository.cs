namespace Axh.Core.Repositories.Wedding
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    using Axh.Core.DbContexts.Contracts.Activators;
    using Axh.Core.DbContexts.WeddingContext;
    using Axh.Core.DomainModels.Accounts;
    using Axh.Core.Repositories.Common;
    using Axh.Core.Repositories.Wedding.Contracts;
    using Axh.Core.Services.Logging.Contracts;

    public class UserRepository : RepositoryBase<WeddingContext>, IUserRepository
    {
        public UserRepository(IDbContextActivator<WeddingContext> dbContextActivator, ILoggingService loggingService) : base(dbContextActivator, loggingService)
        {
        }

        public async Task<bool> CreateAsync(User user)
        {
            var context = this.DbContext;
            context.Users.Add(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return await this.SaveAsync(context);
        }

        public async Task<bool> UpdateAsync(User request)
        {
            var context = this.DbContext;

            var user = context.Users.FirstOrDefault(x => x.Id == request.Id);

            if (user == null)
            {
                return false;
            }

            if (request.UserName != null)
            {
                user.UserName = request.UserName;
            }

            if (request.PasswordHash != null)
            {
                user.PasswordHash = request.PasswordHash;
            }

            if (request.SecurityStamp != null)
            {
                user.SecurityStamp = request.SecurityStamp;
            }

            if (request.Email != null)
            {
                user.Email = request.Email;
            }

            user.EmailConfirmed = request.EmailConfirmed;

            if (request.PhoneNumber != null)
            {
                user.PhoneNumber = request.PhoneNumber;
            }

            user.PhoneNumberConfirmed = request.PhoneNumberConfirmed;

            Crud(user.Roles, request.Roles, r => r.Id, (r, rr) => { });
            Crud(user.Guests, request.Guests, r => r.Id,
                (g, gg) =>
                {
                    g.FirstName = gg.FirstName;
                    g.Surname = gg.Surname;
                    g.GuestType = gg.GuestType;
                });
            
            context.Entry(user).State = EntityState.Modified;
            return await this.SaveAsync(context);
        }

        public async Task<bool> DeleteAsync(User user)
        {
            var context = this.DbContext;
            context.Users.Remove(user);
            context.Configuration.ValidateOnSaveEnabled = false;
            return await this.SaveAsync(context);
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            return await this.DbContext.Users.FindAsync(userId);
        }

        public async Task<User> FindByNameAsync(string userName)
        {
            return await this.DbContext.Users.FirstOrDefaultAsync(x => x.UserName == userName);
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await this.DbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IList<User>> GetAllAsync()
        {
            return await this.DbContext.Users.ToListAsync();
        }
    }
}
