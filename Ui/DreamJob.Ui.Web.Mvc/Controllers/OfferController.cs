﻿using DreamJob.Ui.Web.Mvc.Helpers;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Text;
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
            var operationResult = this.profileBusiness.AcceptOffer(model);
            var result = new JsonResult { Data = operationResult };
            return result;
        }

        public ActionResult RejectOffer(long id)
        {
            var operationResult = this.profileBusiness.RejectOffer(id);
            var result = new JsonResult { Data = operationResult };
            return result;
        }

        public ActionResult CancelOffer(long id)
        {
            var operationResult = this.profileBusiness.CancelOffer(id);
            var result = new JsonResult { Data = operationResult };
            return result;
        }
    }

    public class AcceptOfferDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string ContactMethod { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name: {0}<br/>", this.Name);
            sb.AppendFormat("Note: {0}<br/>", this.Note);
            sb.AppendFormat("ContactMethod: {0}<br/>", this.ContactMethod);
            sb.AppendFormat("Email: {0}<br/>", this.Email);
            sb.AppendFormat("Phone: {0}<br/>", this.Phone);

            return sb.ToString();
        }
    }
}