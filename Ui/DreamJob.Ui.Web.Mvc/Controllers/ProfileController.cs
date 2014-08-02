using DreamJob.Ui.Web.Mvc.BusinessServices;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using DreamJob.Common.Enum;

    public class ProfileController : Controller
    {
        private readonly IProfileBusiness profileBusiness;

        public ProfileController(IProfileBusiness profileBusiness)
        {
            this.profileBusiness = profileBusiness;
        }

        [HttpGet]
        public ActionResult Index()
        {

            var getprofileResult = this.profileBusiness.GetCurrentUserProfile();
            if (getprofileResult.IsSuccess)
            {
                return this.View("Index", getprofileResult.Data);
            }

            throw new InvalidOperationException(
                string.Join(
                    ";",getprofileResult.Errors));
        }
    }

    public class UserProfileDto
    {
        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public DateTime Registered { get; set; }

        public UserAccountType AccountType { get; set; }
    }
}