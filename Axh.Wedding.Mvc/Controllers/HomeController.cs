namespace Axh.Wedding.Mvc.Controllers
{
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
            var isAdmin = User.IsInRole("admin");
            var model = homePageViewModelService.GetHomePageViewModel(user, isAdmin);
            return View(model);
        }

        public virtual ActionResult Information()
        {
            var user = User.Identity.GetUserName();
            var isAdmin = User.IsInRole("admin");
            var model = homePageViewModelService.GetInformationPageViewModel(user, isAdmin);
            return View(model);
        }

        public virtual ActionResult Contact()
        {
            var user = User.Identity.GetUserName();
            var isAdmin = User.IsInRole("admin");
            var model = homePageViewModelService.GetContactPageViewModel(user, isAdmin);
            return View(model);
        }
    }
}