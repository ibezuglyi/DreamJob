using System.Collections.Generic;
using DreamJob.Model.Domain;

namespace DreamJob.Ui.Web.Mvc.Services
{
    public interface IOfferService
    {
        List<JobOffer> GetOffers(long userId);
    }
}