namespace DreamJob.Ui.Web.Mvc.Areas.Api.Controllers
{
    using System.Collections.Generic;

    using AutoMapper;

    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public class OffersLogic : IOffersLogic
    {
        private readonly IOfferService offersService;

        public OffersLogic(IOfferService offersService)
        {
            this.offersService = offersService;
        }

        public List<JobOfferDto> GetOffersForUser(long userId)
        {
            var offers = this.offersService.GetOffers(userId);
            var result = Mapper.Map<List<JobOffer>, List<JobOfferDto>>(offers);
            return result;
        }
    }
}