namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.BusinessServices;

    public class OfferController : Controller
    {
        private readonly IOffersBusiness profileBusiness;

        private readonly ISession session;

        public OfferController(IOffersBusiness profileBusiness, ISession session)
        {
            this.profileBusiness = profileBusiness;
            this.session = session;
        }

        [HttpGet]
        [Authorize]
        public JsonResult MyOffers()
        {
            var currentUser = this.session.GetCurrentUser().Data;
            var offers = this.profileBusiness.GetOffersForUser(currentUser.Id);
            var result = new JsonResult { Data = offers.Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [HttpGet]
        [Authorize]
        public JsonResult OfferDetails(long id)
        {
            var offer = this.profileBusiness.GetDetailsForOffer(id);
            var result = new JsonResult { Data = offer.Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }
    }
}
