namespace DreamJob.Ui.Web.Mvc.Services
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Repositories;

    public class OfferService : IOfferService
    {
        private readonly IOffersRepository offersRepository;

        public OfferService(IOffersRepository offersRepository)
        {
            this.offersRepository = offersRepository;
        }

        public DjOperationResult<List<JobOffer>> GetOffers(long userId)
        {
            var offers = this.offersRepository.OffersTo(userId);
            var result = new DjOperationResult<List<JobOffer>>(offers.Data);
            return result;
        }

        public DjOperationResult<JobOfferDetailsDto> GetDetails(long offerId)
        {
            var offerResult = this.offersRepository.GetDetails(offerId);
            if (offerResult.IsSuccess == false)
            {
                return new DjOperationResult<JobOfferDetailsDto>(false, offerResult.Errors);
            }
            var offerData = offerResult.Data;
            var resultData = AutoMapper.Mapper.Map<JobOffer, JobOfferDetailsDto>(offerData);
            var result = new DjOperationResult<JobOfferDetailsDto>(resultData);
            return result;
        }
    }
}