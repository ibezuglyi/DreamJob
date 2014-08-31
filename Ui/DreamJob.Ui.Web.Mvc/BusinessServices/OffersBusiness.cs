namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Collections.Generic;

    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.BusinessServices;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Services;

    using Microsoft.Ajax.Utilities;

    public class OffersBusiness : IOffersBusiness
    {
        private readonly IOfferService offersService;
        private readonly ISession session;

        public OffersBusiness(IOfferService offersService, ISession session)
        {
            this.offersService = offersService;
            this.session = session;
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

        public DjOperationResult<bool> SendOfferFromCurrentRecruiter(NewJobOfferDto model)
        {
            var getCurrentUserResult = this.session.GetCurrentUser();
            if (getCurrentUserResult.IsSuccess == false)
            {
                return new DjOperationResult<bool>(false, getCurrentUserResult.Errors);
            }

            var currentUserData = getCurrentUserResult.Data;
            var sendResult = this.offersService.SendJobOffer(currentUserData.Id, model);
            return sendResult;
        }
    }
}