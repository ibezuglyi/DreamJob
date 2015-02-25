namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Dtos;
    using DreamJob.Infrastructure;
    using DreamJob.Services;
    using DreamJob.ViewModels;

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
        public ActionResult Register()
        {
            return this.View("Register");
        }

        [HttpGet]
        public ActionResult Login()
        {
            var viewModel = new ProfileLoginViewModel();
            return this.View("Login", viewModel);
        }

        public ActionResult Logout()
        {
            this.accountService.Logout();
            return this.RedirectToAction("Index", "Home");
        }

        [HttpPost]
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
                return this.RedirectToAction("LoginSuccess", "Profile");
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
        public ActionResult RegisterDeveloper()
        {
            var viewmodel = new ProfileRegisterViewModel();
            return this.View("RegisterDeveloper", viewmodel);
        }

        [HttpPost]
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
            return this.View("Edit", viewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProfilePrivateEditDto dto)
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
                    this.profileService.UpdatePrivateProfile(dto);
                }
                return this.RedirectToAction("Edit", "Profile");
            }
            var viewmodel = new ProfilePrivateViewModel(dto);
            return this.View("Edit", viewmodel);
        }


        [HttpGet]
        public ActionResult RegistrationSuccess()
        {
            var viewModel = new ProfileRegistrationSuccessViewModel();
            return this.View("RegistrationSuccess", viewModel);
        }

        [HttpGet]
        public ActionResult RegisterRecruiter()
        {
            var viewmodel = new ProfileRegisterViewModel();
            return this.View("RegisterRecruiter", viewmodel);
        }

        [HttpPost]
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
    }
}