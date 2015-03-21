﻿namespace DreamJob.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using DreamJob.Dtos;
    using DreamJob.Infrastructure;
    using DreamJob.Services;
    using DreamJob.ViewModels;

    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IProfileService profileService;

        private readonly IAccountService accountService;

        public ProfileController(IProfileService profileService, IAccountService accountService)
        {
            this.profileService = profileService;
            this.accountService = accountService;
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return this.View("Register");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var viewModel = new ProfileLoginViewModel(returnUrl);
            return this.View("Login", viewModel);
        }

        public ActionResult Logout()
        {
            this.accountService.Logout();
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(ProfileLoginDto dto)
        {
            if (this.ModelState.IsValid == false)
            {
                var viewModel = new ProfileLoginViewModel(dto);
                return this.View("Login", viewModel);
            }
            var correct = this.accountService.Login(dto);
            if (correct)
            {
                if (string.IsNullOrWhiteSpace(dto.ReturnUrl))
                {
                    return this.RedirectToAction("LoginSuccess", "Profile");
                }
                else
                {
                    return this.Redirect(dto.ReturnUrl);
                }
            }
            else
            {
                this.ModelState.AddModelError("", "No user can be logged in using data you entered.");
                var viewModel = new ProfileLoginViewModel(dto);
                return this.View("Login", viewModel);
            }
        }

        [HttpGet]
        public ActionResult LoginSuccess()
        {
            var viewModel = new ProfileLoginSuccessViewModel();
            return this.View("LoginSuccess", viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegisterDeveloper()
        {
            var viewmodel = new ProfileRegisterViewModel();
            return this.View("RegisterDeveloper", viewmodel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterDeveloper(ProfileRegisterDto dto)
        {
            if (this.ModelState.IsValid == false)
            {
                var viewmodel = new ProfileRegisterViewModel(dto);
                return this.View("RegisterDeveloper", viewmodel);
            }
            this.accountService.RegisterDeveloper(dto);
            return this.RedirectToAction("RegistrationSuccess", "Profile");
        }

        [HttpGet]
        public ActionResult Public(long id)
        {
            var viewmodel = this.profileService.GetPublicDataForUserId(id);
            return this.View("Public", viewmodel);
        }

        [HttpGet]
        public ActionResult Me()
        {
            var viewModel = this.profileService.GetPublicDataForLoggedUser();
            return this.View("Me", viewModel);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            var viewModel = this.profileService.GetPrivateDataForLoggedUser();
            viewModel.FormActionUpdateDeveloper = this.Url.Action("UpdateDeveloper", "Profile");
            viewModel.FormActionUpdateRecruiter = this.Url.Action("UpdateRecruiter", "Profile");
            return this.View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult UpdateDeveloper(ProfilePrivateDeveloperEditDto dto)
        {
            if (this.ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(dto.Action) == false)
                {
                    var skillId = long.Parse(dto.Action);
                    this.profileService.RemoveSkillFromProfile(skillId);
                }
                else
                {
                    this.profileService.UpdateDeveloperProfile(dto);
                }
                return this.RedirectToAction("Edit", "Profile");
            }
            var viewmodel = new ProfilePrivateViewModel(dto);
            return this.View("Edit", viewmodel);
        }

        [HttpPost]
        public ActionResult UpdateRecruiter(ProfilePrivateRecruiterDto dto)
        {
            if (this.ModelState.IsValid)
            {
                this.profileService.UpdateRecruiterProfile(dto);
                return this.RedirectToAction("Edit", "Profile");
            }
            var viewmodel = new ProfilePrivateViewModel(dto);
            return this.View("Edit", viewmodel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegistrationSuccess()
        {
            var viewModel = new ProfileRegistrationSuccessViewModel();
            return this.View("RegistrationSuccess", viewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult RegisterRecruiter()
        {
            var viewmodel = new ProfileRegisterViewModel();
            return this.View("RegisterRecruiter", viewmodel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterRecruiter(ProfileRegisterDto dto)
        {
            if (this.ModelState.IsValid == false)
            {
                var viewmodel = new ProfileRegisterViewModel(dto);
                return this.View("RegisterRecruiter", viewmodel);
            }

            this.accountService.RegisterRecruiter(dto);
            return this.RedirectToAction("RegistrationSuccess", "Profile");
        }

        [HttpPost]
        public ActionResult RemoveDeveloperSkill(RemoveSkillDto dto)
        {
            var result = new DjJsonResultDto<string>();
            if (this.ModelState.IsValid)
            {
                this.profileService.RemoveSkillFromProfile(dto.SkillId);
                result.Success = true;
                result.Data = "Skill removed successfully";
            }
            else
            {
                result.Success = false;
                var errors = this.ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                result.Errors = errors.ToList();
            }
            var jsonResult = new JsonResult { Data = result };
            return jsonResult;
        }
    }
}