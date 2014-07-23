namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    public class RegisterController : Controller
    {
        private readonly IRegisterBusiness business;

        public RegisterController(IRegisterBusiness business)
        {
            this.business = business;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var data = this.business.GetRegisterViewModel();
            var result = data.Data;
            return this.View("Index", result);
        }

        [HttpPost]
        public ActionResult RegisterDeveloper(RegisterUserViewModel model)
        {
            List<string> errors;
            if (this.ModelState.IsValid)
            {
                var result = this.business.RegisterDeveloper(model);
                if (result.IsSuccess)
                {
                    return this.RedirectToAction("Registered", "Register");
                }
                errors = result.Errors;
            }
            else
            {
                errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            return Json(errors);
        }

        [HttpPost]
        public ActionResult RegisterRecruiter(RegisterUserViewModel model)
        {
            List<string> errors;
            if (this.ModelState.IsValid)
            {
                var result = this.business.RegisterRecruiter(model);
                if (result.IsSuccess)
                {
                    return this.RedirectToAction("Registered", "Register");
                }
                errors = result.Errors;
            }
            else
            {
                errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            return Json(errors);
        }
    }
}