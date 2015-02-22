namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Services;

    public class HomeController : Controller
    {
        private readonly IProfileService profileService;

        public HomeController(IProfileService profileService)
        {
            this.profileService = profileService;
        }

        public ActionResult Index()
        {
            var viewmodel = this.profileService.GetDevelopersHeadlines();
            return this.View("Index", viewmodel);
        }
    }
}