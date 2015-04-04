using System.Web.Mvc;

namespace DreamJob.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            return this.View("Index");
        }
    }
}