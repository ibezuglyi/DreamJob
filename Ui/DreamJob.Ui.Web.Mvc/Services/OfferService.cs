namespace DreamJob.Ui.Web.Mvc.Services
{
    using System.Collections.Generic;

    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Helpers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Repositories;

    public class OfferService : IOfferService
    {
        private readonly IOffersRepository offersRepository;

        private readonly IDateTimeAdapter dateTimeAdapter;

        public OfferService(IOffersRepository offersRepository, IDateTimeAdapter dateTimeAdapter)
        {
            this.offersRepository = offersRepository;
            this.dateTimeAdapter = dateTimeAdapter;
        }

        public DjOperationResult<List<JobOffer>> GetOffersTo(long userId)
        {
            var offers = this.offersRepository.OffersTo(userId);
            var result = new DjOperationResult<List<JobOffer>>(offers.Data);
            return result;
        }

        public DjOperationResult<List<JobOffer>> GetOffersFrom(long recruiterId)
        {
            var offers = this.offersRepository.OffersFrom(recruiterId);
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
            var resultData = Mapper.Map<JobOffer, JobOfferDetailsDto>(offerData);
            var result = new DjOperationResult<JobOfferDetailsDto>(resultData);
            return result;
        }

        public DjOperationResult<bool> SendJobOffer(long recruiterUserId, NewJobOfferDto model)
        {
            var jobOffer = Mapper.Map<NewJobOfferDto, JobOffer>(model);

            jobOffer.FromRecruiterId = recruiterUserId;
            jobOffer.Add = this.dateTimeAdapter.Now;
            jobOffer.Edit = this.dateTimeAdapter.Now;

            var insertResult = this.offersRepository.InsertOffer(jobOffer);
            return insertResult;
        }

        public DjOperationResult<bool> MarkOffer(long offerId, long userId, OfferStatus offerStatus)
        {
            var getOfferResult  = this.offersRepository.GetOffer(offerId);
            var offer = getOfferResult.Data;
            offer.OfferStatus = offerStatus;
            offer.Edit = this.dateTimeAdapter.Now;
            var operationResult = this.offersRepository.UpdateStatus(offer);
            return operationResult;
        }
    }
}