
namespace Axh.Core.DomainModels.Accounts
{
    using System;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser<Guid, IdentityUserLogin<Guid>, IdentityUserRole<Guid>, IdentityUserClaim<Guid>>
    {

    }
}
