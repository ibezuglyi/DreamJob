namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            var viewmodel = new ErrorIndexViewModel();
            return this.View("Index", viewmodel);
        }

        public ActionResult NotFound()
        {
            var viewmodel = new ErrorNotFoundViewModel();
            return this.View("NotFound", viewmodel);
        }

    }

    public class ErrorNotFoundViewModel
    {
    }

    public class ErrorIndexViewModel
    {
    }
}