namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Helpers;

    [Authorize]
    public class NotificationController : Controller
    {
        [HttpGet]
        public ActionResult GetNewOffersCount()
        {
            return this.DjJson<int>(new DjOperationResult<int>(10));
        }   
    }
}