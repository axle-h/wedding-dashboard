namespace Axh.Wedding.Mvc.Controllers
{
    using System.Web.Mvc;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Admin;
    using Microsoft.AspNet.Identity;

    [Authorize(Roles = "admin")]
    public partial class AdminController : Controller
    {
        private readonly IAdminViewModelService adminViewModelService;

        public AdminController(IAdminViewModelService adminViewModelService)
        {
            this.adminViewModelService = adminViewModelService;
        }

        public virtual ActionResult Index()
        {
            var user = User.Identity.GetUserName();
            var model = this.adminViewModelService.GetAdminPageViewModel(user);
            return View(model);
        }
    }
}