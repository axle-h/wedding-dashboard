namespace Axh.Wedding.Mvc.Controllers
{
    using System.Web.Mvc;

    using Axh.Wedding.Application.Contracts.ViewModelServices.Rsvp;

    public partial class RsvpController : Controller
    {
        private readonly IRsvpViewModelService rsvpViewModelService;

        public RsvpController(IRsvpViewModelService rsvpViewModelService)
        {
            this.rsvpViewModelService = rsvpViewModelService;
        }

        public virtual ActionResult Index()
        {
            var model = this.rsvpViewModelService.GetRsvpPageViewModel();
            return View(model);
        }
    }
}