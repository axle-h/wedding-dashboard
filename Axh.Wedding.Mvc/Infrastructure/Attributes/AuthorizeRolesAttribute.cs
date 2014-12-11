namespace Axh.Wedding.Mvc.Infrastructure.Attributes
{
    using System.Web.Mvc;

    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params string[] roles)
        {
            Roles = string.Join(",", roles);
        }
    }
}