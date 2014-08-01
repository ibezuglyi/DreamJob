namespace DreamJob.Ui.Web.Mvc.Areas.Api.Controllers
{
    using System.Collections.Generic;

    using DreamJob.Model.Domain;

    public interface IOfferService
    {
        List<JobOffer> GetOffers(long userId);
    }
}