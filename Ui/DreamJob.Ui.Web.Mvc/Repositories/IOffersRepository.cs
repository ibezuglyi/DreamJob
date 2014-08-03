using System.Collections.Generic;
using DreamJob.Model.Domain;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
    public interface IOffersRepository
    {
        List<JobOffer> OffersTo(long userId);
    }
}