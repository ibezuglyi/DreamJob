namespace DreamJob.Ui.Web.Mvc.Services
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IOfferService
    {
        DjOperationResult<List<JobOffer>> GetOffersTo(long developerUserid);
        DjOperationResult<List<JobOffer>> GetOffersFrom(long recruiterId);
        DjOperationResult<JobOfferDetailsDto> GetDetails(long offerId);
        DjOperationResult<bool> SendJobOffer(long recruiterUserId, NewJobOfferDto model);

    }
}