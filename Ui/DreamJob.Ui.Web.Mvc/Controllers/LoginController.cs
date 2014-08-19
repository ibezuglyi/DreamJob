using DreamJob.Ui.Web.Mvc.BusinessServices;
using DreamJob.Ui.Web.Mvc.Models.Dto;

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

        [HttpGet]
        public ActionResult Index()
        {
            var result = this.business.GetLoginViewModel();
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