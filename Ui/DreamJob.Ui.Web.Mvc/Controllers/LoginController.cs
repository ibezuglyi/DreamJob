namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class LoginController : Controller
    {
        private readonly ILoginBusiness business;

        public LoginController(ILoginBusiness business)
        {
            this.business = business;
        }

        public ActionResult Index()
        {
            var result = this.business.GetLoginViewModel();
            return this.View("Index", result.Data);
        }
    }
}