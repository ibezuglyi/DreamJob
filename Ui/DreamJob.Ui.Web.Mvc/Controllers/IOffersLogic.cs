namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IOffersLogic
    {
        DjOperationResult<List<JobOfferDto>> GetOffersForUser(long userId);
        DjOperationResult<JobOfferDetailsDto> GetDetailsForOffer(long offerId);
    }
}