using System.Collections.Generic;
using DreamJob.Model.Domain;

namespace DreamJob.Ui.Web.Mvc.Services
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public interface IOfferService
    {
        DjOperationResult<List<JobOffer>> GetOffers(long userId);

        DjOperationResult<JobOfferDetailsDto> GetDetails(long offerId);
    }
}