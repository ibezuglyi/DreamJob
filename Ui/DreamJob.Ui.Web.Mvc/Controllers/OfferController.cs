using DreamJob.Ui.Web.Mvc.Helpers;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Web.Mvc;

    using DreamJob.Ui.Web.Mvc.BusinessServices;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

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
        public ActionResult MyOffers()
        {
            var currentUser = this.session.GetCurrentUser().Data;
            var offers = this.profileBusiness.GetOffersForUser(currentUser);
            var result = new JsonResult { Data = offers.Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var currentUser = this.session.GetCurrentUser().Data;
            var viewModel = new OfferIndexViewModel(currentUser);
            return this.View("Index", viewModel);
        }

        [HttpGet]
        [Authorize]
        public ActionResult OfferDetails(long id)
        {
            var offer = this.profileBusiness.GetDetailsForOffer(id);
            var result = new JsonResult { Data = offer.Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }

        [HttpPost]
        [Authorize]
        public ActionResult Send(NewJobOfferDto model)
        {

            var operationResult = this.profileBusiness.SendOfferFromCurrentRecruiter(model, this.GetSystemLoginUrl());
            var result = new JsonResult { Data = operationResult };
            return result;
        }

        [HttpPost]
        [Authorize]
        public ActionResult AcceptOffer(AcceptOfferDto model)
        {
            var operationResult = this.profileBusiness.AcceptOffer(model, this.GetSystemLoginUrl());
            var result = new JsonResult { Data = operationResult };
            return result;
        }
        [HttpPost]
        [Authorize]
        public ActionResult RejectOffer(long id)
        {
            var operationResult = this.profileBusiness.RejectOffer(id, this.GetSystemLoginUrl());
            var result = new JsonResult { Data = operationResult };
            return result;
        }
        [HttpPost]
        [Authorize]
        public ActionResult CancelOffer(long id)
        {
            var operationResult = this.profileBusiness.CancelOffer(id, this.GetSystemLoginUrl());
            var result = new JsonResult { Data = operationResult };
            return result;
        }
    }
}