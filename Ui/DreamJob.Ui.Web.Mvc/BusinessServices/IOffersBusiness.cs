namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IOffersBusiness
    {
        DjOperationResult<List<JobOfferDto>> GetOffersForUser(LoginUserDto userId);
        DjOperationResult<JobOfferDetailsDto> GetDetailsForOffer(long offerId);
        DjOperationResult<bool> SendOfferFromCurrentRecruiter(NewJobOfferDto model);

        DjOperationResult<bool> AcceptOffer(AcceptOfferDto id);
        DjOperationResult<bool> RejectOffer(long id);
        DjOperationResult<bool> CancelOffer(long id);
    }
}