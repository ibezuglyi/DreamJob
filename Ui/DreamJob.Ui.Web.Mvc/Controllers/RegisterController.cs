using DreamJob.Ui.Web.Mvc.BusinessServices;
using DreamJob.Ui.Web.Mvc.Models.Dto;

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
        public ActionResult RegisterDeveloper(UserRegistrationDto user)
        {
            List<string> errors;
            if (this.ModelState.IsValid)
            {
                var result = this.business.RegisterDeveloper(user);
                if (result.IsSuccess)
                {
                    return new JsonResult { Data = result.Data };
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
        public ActionResult RegisterRecruiter(UserRegistrationDto user)
        {
            List<string> errors;
            if (this.ModelState.IsValid)
            {
                var result = this.business.RegisterRecruiter(user);
                if (result.IsSuccess)
                {
                    return new JsonResult() { Data = result.Data };
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
        public ActionResult Registered(string hash)
        {
            this.business.ConfirmUserRegistration(hash);
            return new JsonResult(){ Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }
    }
}