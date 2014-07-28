namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class ProfileController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "--- user profile goes here ---";
        }
    }
}