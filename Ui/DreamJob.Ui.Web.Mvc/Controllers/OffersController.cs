﻿namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;
    using System.Text;
    using System.Web.Helpers;
    using System.Web.Mvc;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Areas.Api.Controllers;

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
            var result = new JsonResult { Data = offers, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            return result;
        }
    }

    public class JobOfferDto
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime Add { get; set; }
        public string From { get; set; }
        public string To{ get; set; }
        public string Description { get; set; }
        public OfferStatus OfferStatus { get; set; }
    }
}
