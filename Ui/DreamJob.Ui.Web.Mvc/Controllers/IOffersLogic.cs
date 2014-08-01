namespace DreamJob.Ui.Web.Mvc.Areas.Api.Controllers
{
    using System.Collections.Generic;

    using DreamJob.Ui.Web.Mvc.Controllers;

    public interface IOffersLogic
    {
        List<JobOfferDto> GetOffersForUser(long userId);
    }
}