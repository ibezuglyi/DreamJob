namespace DreamJob.Controllers
{
    using System.Web.Mvc;

    using ViewModels;

    public class ErrorController : DjBaseController
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
}