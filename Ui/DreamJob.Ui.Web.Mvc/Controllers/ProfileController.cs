namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.BusinessServices;
    using DreamJob.Ui.Web.Mvc.Helpers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;


    public class ProfileController : BaseController
    {
        private readonly IProfileBusiness profileBusiness;

        private readonly ISession session;

        public ProfileController(IProfileBusiness profileBusiness, ISession session, IEmailService emailService)
            : base(emailService)
        {
            this.profileBusiness = profileBusiness;
            this.session = session;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View("Index");
        }

        [HttpPost]
        [Authorize]
        public JsonResult SaveRecruiterProfile(SaveRecruiterProfileDto model)
        {
            this.profileBusiness.UpdateRecruiterProfile(model);
            return Json(true);
        }

        [HttpPost]
        [Authorize]
        public JsonResult SaveDeveloperProfile(SaveDeveloperProfileDto model)
        {
            this.profileBusiness.UpdateDeveloperProfile(model);
            return Json(true);
        }

        [HttpGet]
        [Authorize]
        public JsonResult CurrentUser()
        {
            var getprofileResult = this.profileBusiness.GetCurrentUserProfile();
            return Json(getprofileResult, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetCities(string cityPart)
        {
            var cities = this.profileBusiness.GetDeveloperCities(cityPart);
            return this.DjJson(cities);
        }

        [HttpGet]
        public JsonResult Search(string technology, string city)
        {
            var developers = this.profileBusiness.SearchForDevelopers(technology, city);
            return this.DjJson(developers);
        }
    }
}