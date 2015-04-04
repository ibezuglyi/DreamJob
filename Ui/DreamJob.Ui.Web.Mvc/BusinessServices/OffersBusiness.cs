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

            var currentUser = getCurrentUserResult.Data;
            var sendResult = this.offersService.SendJobOffer(currentUser.Id, model);
            emailService.NotifyNewMessageReceived(developer.Data.Email, model.Subject, developer.Data.DisplayName, currentUser.DisplayName, url);
            return sendResult;
        }

        public DjOperationResult<bool> AcceptOffer(AcceptOfferDto model, string loginUrl)
        {
            var getUserResult = this.session.GetCurrentUser();
            var currentUser = getUserResult.Data;
            if (currentUser.AccountType == UserAccountType.Recruiter)
            {
                return new DjOperationResult<bool>(false, new[] { "Only developer can mark an offer as accepted" });
            }

            var developerDetailsText = model.ToString();

            var addCommentsResult = this.commentService.AddNewComment(model.Id, developerDetailsText, currentUser.Id);
            if (addCommentsResult.IsSuccess == false)
            {
                return new DjOperationResult<bool>(false, addCommentsResult.Errors);
            }

            var operationResult = this.MarkOffer(model.Id, currentUser.Id, OfferStatus.Accepted);
            var offer = offersService.GetJobOffer(model.Id);
            emailService.NotifyOfferAccepted(offer.Data.FromRecruiter.Email, offer.Data.FromRecruiter.DisplayName, offer.Data.ToDeveloper.Title, loginUrl);
            return operationResult;
        }

        public DjOperationResult<bool> RejectOffer(long id, string loginUrl)
        {
            var getUserResult = this.session.GetCurrentUser();
            var currentUser = getUserResult.Data;
            if (currentUser.AccountType == UserAccountType.Recruiter)
            {
                return new DjOperationResult<bool>(false, new[] { "Only developer can mark an offer as rejected" });
            }

            var operationResult = this.MarkOffer(id, currentUser.Id, OfferStatus.Rejected);
            var offer = offersService.GetJobOffer(id);
            emailService.NotifyOfferRejected(offer.Data.FromRecruiter.Email, offer.Data.FromRecruiter.DisplayName, offer.Data.ToDeveloper.Title, loginUrl);
            return operationResult;
        }

        public DjOperationResult<bool> CancelOffer(long id, string loginUrl)
        {
            var getUserResult = this.session.GetCurrentUser();
            var currentUser = getUserResult.Data;
            if (currentUser.AccountType == UserAccountType.Developer)
            {
                return new DjOperationResult<bool>(false, new[] { "Only recruited can cancel the offer" });
            }

            var operationResult = this.MarkOffer(id, currentUser.Id, OfferStatus.Canceled);
            var offer = offersService.GetJobOffer(id);
            emailService.NotifyOfferCanceled(offer.Data.ToDeveloper.Email, offer.Data.ToDeveloper.DisplayName, offer.Data.Subject, loginUrl);
            return operationResult;
        }

        private DjOperationResult<bool> MarkOffer(long offerId, long userId, OfferStatus offerStatus)
        {
            var operationStatus = this.offersService.MarkOffer(offerId, userId, offerStatus);
            return new DjOperationResult<bool>();
        }
    }
}