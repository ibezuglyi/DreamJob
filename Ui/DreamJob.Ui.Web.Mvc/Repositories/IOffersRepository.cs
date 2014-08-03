using System.Collections.Generic;
using DreamJob.Model.Domain;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using DreamJob.Common.Enum;

    public interface IOffersRepository
    {
        DjOperationResult<List<JobOffer>> OffersTo(long userId);
        DjOperationResult<JobOffer> GetDetails(long offerId);
    }
}