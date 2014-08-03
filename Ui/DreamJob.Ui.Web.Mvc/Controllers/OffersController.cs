namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.Results;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Areas.Api.Controllers;

    using Newtonsoft.Json;

    public class OffersController : ApiController
    {
        private readonly IOffersLogic profileLogic;

        public OffersController(IOffersLogic profileLogic)
        {
            this.profileLogic = profileLogic;
        }

        [HttpGet]
        public JsonResult<List<JobOfferDto>> Get()
        {
            var offers = this.profileLogic.GetOffersForUser(25);
            var jsonSerializerSettings = new JsonSerializerSettings();
            var result = new JsonResult<List<JobOfferDto>>(offers, jsonSerializerSettings, Encoding.Default, this);
            return result;
        }
    }

    public class JobOfferDto
    {
        public long Id { get; set; }
        public DateTime Add { get; set; }
        public string FromDisplayName { get; set; }
        public string ToDisplayName { get; set; }
        public string Description { get; set; }
        public OfferStatus OfferStatus { get; set; }
    }
}
