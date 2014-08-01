namespace DreamJob.Ui.Web.Mvc.Areas.Api.Controllers
{
    using System.Collections.Generic;

    using DreamJob.Model.Domain;

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