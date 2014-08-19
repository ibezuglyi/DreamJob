namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;

    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Services;

    public class OffersLogic : IOffersLogic
    {
        private readonly IOfferService offersService;

        public OffersLogic(IOfferService offersService)
        {
            this.offersService = offersService;
        }

        public DjOperationResult<List<JobOfferDto>> GetOffersForUser(long userId)
        {
            var offers = this.offersService.GetOffers(userId);
            var result = Mapper.Map<List<JobOffer>, List<JobOfferDto>>(offers.Data);
            return new DjOperationResult<List<JobOfferDto>>(result);
        }

        public DjOperationResult<JobOfferDetailsDto> GetDetailsForOffer(long offerId)
        {
            var offer = this.offersService.GetDetails(offerId);
            return offer;
        }
    }
}