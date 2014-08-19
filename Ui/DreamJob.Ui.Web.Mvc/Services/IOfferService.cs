namespace DreamJob.Ui.Web.Mvc.Services
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public interface IOfferService
    {
        DjOperationResult<List<JobOffer>> GetOffers(long userId);

        DjOperationResult<JobOfferDetailsDto> GetDetails(long offerId);
    }
}