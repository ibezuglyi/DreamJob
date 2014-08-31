namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IOffersBusiness
    {
        DjOperationResult<List<JobOfferDto>> GetOffersForUser(long userId);
        DjOperationResult<JobOfferDetailsDto> GetDetailsForOffer(long offerId);
        DjOperationResult<bool> SendOfferFromCurrentRecruiter(NewJobOfferDto model);
    }
}