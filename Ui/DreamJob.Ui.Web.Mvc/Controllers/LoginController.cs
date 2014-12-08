namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.BusinessServices;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public class LoginController : Controller
    {
        private readonly ILoginBusiness business;
        private const string loginHeaderName = "x-login";

        public LoginController(ILoginBusiness business)
        {
            this.business = business;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var result = this.business.GetLoginViewModel();
            Response.AddHeader(loginHeaderName, Url.Action("Index", "Login"));
            return this.View("Index", result.Data);
        }

        [HttpPost]
        public ActionResult Index(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var result = this.business.LoginUser(model);
                if (result.IsSuccess)
                {
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    result.Errors.ForEach(error => ModelState.AddModelError("", error));
                }
            }
            return this.View("Index", model);
        }
    }
}