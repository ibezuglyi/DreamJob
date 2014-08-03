namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.Areas.Api.Controllers;

    public class OffersController:Controller
    {
        private readonly IOffersLogic profileLogic;

        private readonly ISession session;

        public OffersController(IOffersLogic profileLogic, ISession session)
        {
            this.profileLogic = profileLogic;
            this.session = session;
        }

        [HttpGet]
        [Authorize]
        public JsonResult MyOffers()
        {
            var currentUser = this.session.GetCurrentUser().Data;
            var offers = this.profileLogic.GetOffersForUser(currentUser.Id);
            var result = new JsonResult { Data = offers, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }
    }
}
