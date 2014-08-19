namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    public class OffersController : Controller
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
            var result = new JsonResult { Data = offers.Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [HttpGet]
        [Authorize]
        public JsonResult OfferDetails(long id)
        {
            var offer = this.profileLogic.GetDetailsForOffer(id);
            var result = new JsonResult { Data = offer.Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }
    }
}
