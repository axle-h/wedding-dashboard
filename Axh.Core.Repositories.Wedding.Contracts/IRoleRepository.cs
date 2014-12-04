namespace Axh.Core.Repositories.Wedding.Contracts
{
    using System.Threading.Tasks;

    using Axh.Core.DomainModels.Accounts;

    public interface IRoleRepository
    {
        Task<Role> FindByNameAsync(string roleName);
    }
}