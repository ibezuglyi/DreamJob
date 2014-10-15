namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.Helpers;

    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationBusiness bussines;

        public NotificationController(INotificationBusiness bussines)
        {
            this.bussines = bussines;
        }

        [HttpGet]
        public ActionResult GetNewOffersCount()
        {
            var operationResult = this.bussines.GetNewOffersCount();
            var result = this.DjJson(operationResult);
            return result;

        }   
    }
}