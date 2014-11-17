namespace Axh.Wedding.Mvc.Controllers
{
    using System.Web.Mvc;

    using Axh.Wedding.Application.Contracts.ViewModelServices.Home;

    public partial class HomeController : Controller
    {
        private readonly IHomePageViewModelService homePageViewModelService;

        public HomeController(IHomePageViewModelService homePageViewModelService)
        {
            this.homePageViewModelService = homePageViewModelService;
        }

        public virtual ActionResult Index()
        {
            var model = homePageViewModelService.GetHomePageViewModel();
            return View(model);
        }

        public virtual ActionResult Information()
        {
            var model = homePageViewModelService.GetInformationPageViewModel();
            return View(model);
        }

        public virtual ActionResult Contact()
        {
            var model = homePageViewModelService.GetContactPageViewModel();
            return View(model);
        }
    }
}