namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Common.Enum;
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
        public JsonResult CurrentUser(UserProfileDto profile)
        {
            LoginUserDto currentUser = this.session.GetCurrentUser().Data;
            DjOperationResult<bool> updateResult;
            
            if (currentUser.AccountType == UserAccountType.Developer)
            {
                updateResult = this.profileBusiness.UpdateDeveloperProfile(currentUser.Id, profile);
            }
            else
            {
                updateResult = this.profileBusiness.UpdateRecruiterProfile(currentUser.Id, profile);
            }

            return this.DjJson(updateResult);
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
}