namespace Axh.Wedding.Mvc.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Axh.Core.Services.Logging.Contracts;
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
        private readonly ILoggingService loggingService;

        public AccountController(UserManager<WeddingUser, Guid> userManager, IAccountViewModelService accountViewModelService, ILoggingService loggingService)
        {
            this.userManager = userManager;
            this.accountViewModelService = accountViewModelService;
            this.loggingService = loggingService;
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
        public virtual async Task<ActionResult> Login(LoginPageViewModel loginPageViewModel)
        {
            if (!this.ModelState.IsValid)
            {
                loginPageViewModel = this.accountViewModelService.GetLoginViewModel(loginPageViewModel);
                return this.View(loginPageViewModel);
            }

            var user = await this.userManager.FindAsync(loginPageViewModel.UserName, loginPageViewModel.Password);
            if (user != null)
            {
                var authenticationManager = this.HttpContext.GetOwinContext().Authentication;
                authenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
                var identity = await userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                var props = new AuthenticationProperties { IsPersistent = loginPageViewModel.RememberMe };
                authenticationManager.SignIn(props, identity);

                loggingService.Info("User logged in from {0}: {1}", Request.UserHostAddress, loginPageViewModel.UserName);

                if (Url.IsLocalUrl(loginPageViewModel.ReturnUrl))
                {
                    return Redirect(loginPageViewModel.ReturnUrl);
                }

                return this.RedirectToAction(MVC.Home.Index());
            }

            loggingService.Info("Failed login attempt from {0}. {1}: {2}", Request.UserHostAddress, loginPageViewModel.UserName, loginPageViewModel.Password);

            loginPageViewModel = this.accountViewModelService.GetLoginViewModel(loginPageViewModel);
            this.ModelState.AddModelError("password", Resources.Account_InvalidUserNameOrPassword);
            return View(loginPageViewModel);
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