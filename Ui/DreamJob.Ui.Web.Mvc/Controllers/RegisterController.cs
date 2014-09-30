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
            var isUserUnique = CheckUserUniqueness(user);

            if (this.ModelState.IsValid && isUserUnique)
            {
                var result = this.business.RegisterDeveloper(user);
                if (result.IsSuccess)
                {
                    return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return new JsonResult() { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpGet]
        public ActionResult Registered()
        {
            return View();
        }

        private bool CheckUserUniqueness(UserRegistrationDto user)
        {
            var isLoginUnique = business.IsLoginUnique(user.Login);
            var isDisplayNameUnique = business.IsDisplayNameUnique(user.DisplayName);
            var isEmailNameUnique = business.IsDisplayNameUnique(user.Email);
            return isLoginUnique && isDisplayNameUnique && isEmailNameUnique;
        }

        [HttpPost]
        public ActionResult RegisterRecruiter(UserRegistrationDto user)
        {
            var isUserUnique = CheckUserUniqueness(user);

            if (this.ModelState.IsValid && isUserUnique)
            {
                var result = this.business.RegisterRecruiter(user);
                if (result.IsSuccess)
                {
                    return new JsonResult { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return new JsonResult() { Data = false, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        [HttpPost]
        public ActionResult Registered(string hash)
        {
            this.business.ConfirmUserRegistration(hash);
            return new JsonResult() { Data = true, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult CheckEmail(string val)
        {
            var isEmailUnique = business.IsEmailUnique(val);
            return new JsonResult() { Data = isEmailUnique, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult CheckDisplayName(string val)
        {
            var isUnique = business.IsDisplayNameUnique(val);
            return new JsonResult() { Data = isUnique, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult CheckLogin(string val)
        {
            var isUnique = business.IsLoginUnique(val);
            return new JsonResult() { Data = isUnique, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}