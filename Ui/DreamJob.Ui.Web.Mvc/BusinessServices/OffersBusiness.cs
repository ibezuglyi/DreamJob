using System.Security.Policy;
using System.Web.Mvc;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using System.Collections.Generic;

    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Services;

    using Microsoft.Ajax.Utilities;

    using ISession = DreamJob.Ui.Web.Mvc.ISession;

    public class OffersBusiness : IOffersBusiness
    {
        private readonly IOfferService offersService;
        private readonly ISession session;
        private readonly ICommentService commentService;
        private readonly IEmailService emailService;
        private readonly IDeveloperService developerService;

        public OffersBusiness(IOfferService offersService, ISession session, ICommentService commentService, IEmailService emailService, IDeveloperService developerService)
        {
            this.offersService = offersService;
            this.session = session;
            this.commentService = commentService;
            this.emailService = emailService;
            this.developerService = developerService;
        }

        public DjOperationResult<List<JobOfferDto>> GetOffersForUser(LoginUserDto user)
        {
            DjOperationResult<List<JobOffer>> offers;
            if (user.AccountType == UserAccountType.Developer)
            {
                offers = this.offersService.GetOffersTo(user.Id);
            }
            else
            {
                offers = this.offersService.GetOffersFrom(user.Id);
            }

            var result = Mapper.Map<List<JobOffer>, List<JobOfferDto>>(offers.Data);
            return new DjOperationResult<List<JobOfferDto>>(result);
        }

        public DjOperationResult<JobOfferDetailsDto> GetDetailsForOffer(long offerId)
        {
            var offer = this.offersService.GetDetails(offerId);
            return offer;
        }

        public DjOperationResult<bool> SendOfferFromCurrentRecruiter(NewJobOfferDto model, string url)
        {
            var getCurrentUserResult = this.session.GetCurrentUser();
            if (getCurrentUserResult.IsSuccess == false)
            {
                return new DjOperationResult<bool>(false, getCurrentUserResult.Errors);
            }
            var developer = developerService.GetDeveloperPublicProfile(model.DeveloperId);
            
            if (developer.IsSuccess == false)
            {
                return new DjOperationResult<bool>(false, developer.Errors);
            }

            var currentUserData = getCurrentUserResult.Data;
            var sendResult = this.offersService.SendJobOffer(currentUserData.Id, model);
            emailService.NotifyNewMessageReceived(developer.Data.Email, model.Subject, developer.Data.DisplayName, currentUserData.DisplayName, url);
            return sendResult;
        }

        public DjOperationResult<bool> AcceptOffer(AcceptOfferDto model)
        {
            var getUserResult = this.session.GetCurrentUser();
            var currentUser = getUserResult.Data;
            if (currentUser.AccountType == UserAccountType.Recruiter)
            {
                return new DjOperationResult<bool>(false, new[] { "Only developer can mark an offer as accepted" });
            }

            var data = model.ToString();

            var addCommentsResult = this.commentService.AddNewComment(model.Id, data, currentUser.Id);
            if (addCommentsResult.IsSuccess == false)
            {
                return new DjOperationResult<bool>(false, addCommentsResult.Errors);
            }

            var operationResult = this.MarkOffer(model.Id, currentUser.Id, OfferStatus.Accepted);
            return operationResult;
        }

        public DjOperationResult<bool> RejectOffer(long id)
        {
            var getUserResult = this.session.GetCurrentUser();
            var currentUser = getUserResult.Data;
            if (currentUser.AccountType == UserAccountType.Recruiter)
            {
                return new DjOperationResult<bool>(false, new[] { "Only developer can mark an offer as rejected" });
            }

            var operationResult = this.MarkOffer(id, currentUser.Id, OfferStatus.Rejected);
            return operationResult;
        }

        public DjOperationResult<bool> CancelOffer(long id)
        {
            var getUserResult = this.session.GetCurrentUser();
            var currentUser = getUserResult.Data;
            if (currentUser.AccountType == UserAccountType.Developer)
            {
                return new DjOperationResult<bool>(false, new[] { "Only recruited can cancel the offer" });
            }

            var operationResult = this.MarkOffer(id, currentUser.Id, OfferStatus.Canceled);
            return operationResult;
        }

        private DjOperationResult<bool> MarkOffer(long offerId, long userId, OfferStatus offerStatus)
        {
            var operationStatus = this.offersService.MarkOffer(offerId, userId, offerStatus);
            return operationStatus;
        }
    }
}