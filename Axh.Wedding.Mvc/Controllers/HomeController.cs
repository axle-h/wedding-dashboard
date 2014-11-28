﻿namespace Axh.Wedding.Mvc.Controllers
{
    using System.Web;
    using System.Web.Mvc;

    using Axh.Wedding.Application.Contracts.ViewModelServices.Home;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public partial class HomeController : Controller
    {
        private readonly IHomePageViewModelService homePageViewModelService;

        public HomeController(IHomePageViewModelService homePageViewModelService)
        {
            this.homePageViewModelService = homePageViewModelService;
        }

        public virtual ActionResult Index()
        {
            var user = User.Identity.GetUserName();
            var model = homePageViewModelService.GetHomePageViewModel(user);
            return View(model);
        }

        public virtual ActionResult Information()
        {
            var user = User.Identity.GetUserName();
            var model = homePageViewModelService.GetInformationPageViewModel(user);
            return View(model);
        }

        public virtual ActionResult Contact()
        {
            var user = User.Identity.GetUserName();
            var model = homePageViewModelService.GetContactPageViewModel(user);
            return View(model);
        }
    }
}