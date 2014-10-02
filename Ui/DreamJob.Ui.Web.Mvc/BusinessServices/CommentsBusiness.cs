using DreamJob.Model.Domain;
using DreamJob.Ui.Web.Mvc.Services;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public class CommentsBusiness : ICommentBusiness
    {
        private readonly ISession session;

        private readonly ICommentService serviceComment;
        private readonly IOfferService offerService;
        private readonly IEmailService emailService;

        public CommentsBusiness(ISession session, ICommentService serviceComment, IOfferService offerService, IEmailService emailService)
        {
            this.session = session;
            this.serviceComment = serviceComment;
            this.offerService = offerService;
            this.emailService = emailService;
        }

        public DjOperationResult<JobOfferCommentDto> AddNewComment(long offerId, string text, string loginUrl)
        {
            var getUserResult = this.session.GetCurrentUser();
            if (getUserResult.IsSuccess == false)
            {
                return new DjOperationResult<JobOfferCommentDto>(false, getUserResult.Errors);
            }
            var addCommentResult = AddNewComment(offerId, text, getUserResult);
            if (addCommentResult.IsSuccess == false)
            {
                return new DjOperationResult<JobOfferCommentDto>(false, addCommentResult.Errors);
            }
            if (getUserResult.Data.AccountType == UserAccountType.Developer)
            {
                offerService.MarkOffer(offerId, getUserResult.Data.Id, OfferStatus.Read);
            }
            
            NotifyNewCommentAdded(offerId, loginUrl, getUserResult.Data);
            
            var getCommentResult = this.serviceComment.GetCommentWithAuthor(addCommentResult.Data);
            return getCommentResult;
        }

        private void NotifyNewCommentAdded(long offerId, string loginUrl, LoginUserDto userResult)
        {
            var offer = offerService.GetJobOffer(offerId);
            var recepient = userResult.Id == offer.Data.FromRecruiterId
                ? (User) offer.Data.ToDeveloper
                : (User) offer.Data.FromRecruiter;
            emailService.NotifyNewMessageReceived(recepient.Email, recepient.DisplayName, userResult.DisplayName,
                loginUrl);
        }

        private DjOperationResult<long> AddNewComment(long offerId, string text, DjOperationResult<LoginUserDto> getUserResult)
        {
            var currentUser = getUserResult.Data;
            var currentUserId = currentUser.Id;

            var addCommentResult = this.serviceComment.AddNewComment(offerId, text, currentUserId);
            return addCommentResult;
        }
    }
}