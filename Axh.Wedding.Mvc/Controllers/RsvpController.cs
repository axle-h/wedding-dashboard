namespace Axh.Wedding.Mvc.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Axh.Wedding.Application.Contracts.Models.Account;
    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;
    using Axh.Wedding.Application.ViewModels.Rsvp;
    using Axh.Wedding.Mvc.Infrastructure.Attributes;
    using Axh.Wedding.Mvc.Infrastructure.Helpers;

    [AuthorizeRoles(WeddingRoleNames.RsvpDay, WeddingRoleNames.RsvpEvening)]
    public partial class RsvpController : Controller
    {
        private readonly IRsvpViewModelService rsvpViewModelService;

        public RsvpController(IRsvpViewModelService rsvpViewModelService)
        {
            this.rsvpViewModelService = rsvpViewModelService;
        }

        public virtual async Task<ActionResult> Index()
        {
            var user = this.GetCurrentUser();
            var model = await this.rsvpViewModelService.GetRsvpPageViewModel(user);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Index(RsvpPageViewModel viewModel)
        {
            var user = this.GetCurrentUser();

            if (ModelState.IsValid && await this.rsvpViewModelService.UpdateRsvp(user, viewModel))
            {
                return RedirectToAction(MVC.Home.Information());
            }

            viewModel = this.rsvpViewModelService.GetRsvpPageViewModel(user, viewModel);
            return this.View(viewModel);
        }
    }
}