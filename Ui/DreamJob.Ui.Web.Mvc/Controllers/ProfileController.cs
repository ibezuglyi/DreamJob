namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.BusinessServices;
    using DreamJob.Ui.Web.Mvc.Helpers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    
    public class ProfileController : Controller
    {
        private readonly IProfileBusiness profileBusiness;

        private readonly ISession session;

        public ProfileController(IProfileBusiness profileBusiness, ISession session)
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
            return this.DjJson(getprofileResult);
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

    public class SaveDeveloperProfileDto
    {
        public SaveDeveloperProfileDto()
        {
            this.Skills = new List<Skill>();
        }
        public long Id { get; set; }
        public List<Skill> Skills { get; set; }
        public string City { get; set; }
        public long MinSalary { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
        public string ProjectPreferences { get; set; }
        public bool IsLookingForJob { get; set; }
    }

    public class SaveRecruiterProfileDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Company { get; set; }
    }
}