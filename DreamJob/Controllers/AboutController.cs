using System.Web.Mvc;

namespace DreamJob.Controllers
{
    public class AboutController : DjBaseController
    {
        public ActionResult Index()
        {
            return this.View("Index");
        }
    }
}