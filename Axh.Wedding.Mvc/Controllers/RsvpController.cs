namespace Axh.Wedding.Mvc.Controllers
{
    using System.Web.Mvc;

    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public partial class RsvpController : Controller
    {
        private readonly IRsvpViewModelService rsvpViewModelService;

        public RsvpController(IRsvpViewModelService rsvpViewModelService)
        {
            this.rsvpViewModelService = rsvpViewModelService;
        }

        public virtual ActionResult Index()
        {
            var user = User.Identity.GetUserName();
            var model = this.rsvpViewModelService.GetRsvpPageViewModel(user);
            return View(model);
        }
    }
}