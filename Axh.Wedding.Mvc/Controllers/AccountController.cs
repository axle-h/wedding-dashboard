namespace Axh.Wedding.Mvc.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;

    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Account;
    using Axh.Wedding.Application.ViewModels.Account;
    using Axh.Wedding.Resources;

    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;

    public partial class AccountController : Controller
    {
        private readonly UserManager<WeddingUser, Guid> userManager;

        private readonly IAccountViewModelService accountViewModelService;

        public AccountController(UserManager<WeddingUser, Guid> userManager, IAccountViewModelService accountViewModelService)
        {
            this.userManager = userManager;
            this.accountViewModelService = accountViewModelService;
        }

        [HttpGet]
        public virtual ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(MVC.Home.Index());
            }

            var model = this.accountViewModelService.GetLoginViewModel(returnUrl);
            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Login(LoginPageViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var user = await this.userManager.FindAsync(model.UserName, model.Password);
            if (user != null)
            {
                var authenticationManager = this.HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                var props = new AuthenticationProperties { IsPersistent = model.RememberMe };
                authenticationManager.SignIn(props, identity);

                if (Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return this.RedirectToAction(MVC.Home.Index());
            }

            this.ModelState.AddModelError("", Resources.Account_InvalidUserNameOrPassword);
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public virtual ActionResult LogOut()
        {
            var authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut();
            return RedirectToAction(MVC.Account.Login());
        }
    }
}