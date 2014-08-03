using System.Collections.Generic;
using DreamJob.Model.Domain;
using DreamJob.Ui.Web.Mvc.Repositories;

namespace DreamJob.Ui.Web.Mvc.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOffersRepository offersRepository;

        public OfferService(IOffersRepository offersRepository)
        {
            this.offersRepository = offersRepository;
        }

        public List<JobOffer> GetOffers(long userId)
        {
            var offers = this.offersRepository.OffersTo(userId);
            return offers;
        }
    }
}