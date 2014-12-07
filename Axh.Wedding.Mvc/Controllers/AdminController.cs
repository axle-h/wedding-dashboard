namespace Axh.Wedding.Mvc.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Admin;
    using Axh.Wedding.Mvc.Infrastructure.Helpers;

    [Authorize(Roles = WeddingRoleNames.Admin)]
    public partial class AdminController : Controller
    {
        private readonly IAdminViewModelService adminViewModelService;

        public AdminController(IAdminViewModelService adminViewModelService)
        {
            this.adminViewModelService = adminViewModelService;
        }

        public virtual async Task<ActionResult> Index()
        {
            var user = this.GetCurrentUser();
            var model = await this.adminViewModelService.GetAdminPageViewModel(user);
            return View(model);
        }
    }
}