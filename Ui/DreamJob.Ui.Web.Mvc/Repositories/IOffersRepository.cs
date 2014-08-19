namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    public interface IOffersRepository
    {
        DjOperationResult<List<JobOffer>> OffersTo(long userId);
        DjOperationResult<JobOffer> GetDetails(long offerId);
    }
}