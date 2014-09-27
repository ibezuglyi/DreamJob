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

            ValidateUniqueUser(user);

            if (!this.ModelState.IsValid)
            {
                errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            }
            else
            {
                var result = this.business.RegisterDeveloper(user);
                if (result.IsSuccess)
                {
                    return new JsonResult { Data = result.Data };
                }
                errors = result.Errors;
            }
            return Json(errors);
        }

        private void ValidateUniqueUser(UserRegistrationDto user)
        {
            ValidateUniqueEmail(user.Email);
            ValidateUniqueDisplayName(user.DisplayName);
            ValidateUniqueLogin(user.Login);
        }

        private void ValidateUniqueLogin(string login)
        {
            var loginValidationResult = business.IsLoginUnique(login);
            if (!loginValidationResult)
            {
                ModelState.AddModelError("User.Login", "User with this login already exists. Please choose another one.");
            }
        }

        private void ValidateUniqueDisplayName(string displayName)
        {
            var displayNameValidationResult = business.IsDisplayNameUnique(displayName);
            if (!displayNameValidationResult)
            {
                ModelState.AddModelError("User.DisplayName",
                    "User with this display name already exists. Please choose another one.");
            }
        }

        private void ValidateUniqueEmail(string email)
        {

        }

        [HttpPost]
        public ActionResult RegisterRecruiter(UserRegistrationDto user)
        {
            List<string> errors;

            ValidateUniqueUser(user);

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