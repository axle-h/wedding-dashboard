namespace Axh.Wedding.Mvc.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;
    using Axh.Wedding.Application.ViewModels.Rsvp;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public partial class RsvpController : Controller
    {
        private readonly IRsvpViewModelService rsvpViewModelService;

        public RsvpController(IRsvpViewModelService rsvpViewModelService)
        {
            this.rsvpViewModelService = rsvpViewModelService;
        }

        public virtual async Task<ActionResult> Index()
        {
            var user = User.Identity.GetUserName();
            var isAdmin = User.IsInRole("admin");
            var userId = Guid.Parse(User.Identity.GetUserId());
            var model = await this.rsvpViewModelService.GetRsvpPageViewModel(user, isAdmin, userId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Index(RsvpPageViewModel viewModel)
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            if (ModelState.IsValid && await this.rsvpViewModelService.UpdateRsvp(userId, viewModel))
            {
                return RedirectToAction(MVC.Home.Information());
            }

            var user = User.Identity.GetUserName();
            var isAdmin = User.IsInRole("admin");
            viewModel = this.rsvpViewModelService.GetRsvpPageViewModel(user, isAdmin, viewModel);
            return this.View(viewModel);
        }
    }
}