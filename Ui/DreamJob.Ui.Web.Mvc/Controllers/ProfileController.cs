namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.BusinessServices;

    [Authorize]
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
            return this.View("Index");
        }

        [HttpGet]
        public JsonResult CurrentUser()
        {
            var getprofileResult = this.profileBusiness.GetCurrentUserProfile();
            if (getprofileResult.IsSuccess)
            {
                var result = this.Json(getprofileResult.Data, JsonRequestBehavior.AllowGet);
            }

            throw new InvalidOperationException(
                string.Join(
                    ";", getprofileResult.Errors));
        }
    }
}