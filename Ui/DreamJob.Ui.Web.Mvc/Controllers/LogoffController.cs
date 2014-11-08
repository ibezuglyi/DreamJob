using DreamJob.Ui.Web.Mvc.BusinessServices;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class LogoffController : BaseController
    {
        private readonly ILogoffBusiness business;

        public LogoffController(ILogoffBusiness business, IEmailService emailService)
            : base(emailService)
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