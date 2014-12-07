namespace Axh.Wedding.Mvc.Infrastructure.Helpers
{
    using System;
    using System.Web.Mvc;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.ViewModels.Account;
    using Microsoft.AspNet.Identity;

    public static class ControllerExtensions
    {
        public static UserViewModel GetCurrentUser(this Controller controller)
        {
            var user = controller.User.Identity.GetUserName();
            var isAdmin = controller.User.IsInRole(WeddingRoleNames.Admin);
            var userId = Guid.Parse(controller.User.Identity.GetUserId());

            return new UserViewModel
            {
                IsAdmin = isAdmin,
                UserName = user,
                UserId = userId
            };
        }
    }
}