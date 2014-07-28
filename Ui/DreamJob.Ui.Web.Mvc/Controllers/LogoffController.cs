namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class LogoffController : Controller
    {
        private readonly ILogoffBusiness business;

        public LogoffController(ILogoffBusiness business)
        {
            this.business = business;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            this.business.LogoffUser();
            return this.RedirectToAction("Index", "Home");
        }
    }
}