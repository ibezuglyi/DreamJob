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

        public CommentsBusiness(ISession session, ICommentService serviceComment, IOfferService offerService)
        {
            this.session = session;
            this.serviceComment = serviceComment;
            this.offerService = offerService;
        }

        public DjOperationResult<JobOfferCommentDto> AddNewComment(long offerId, string text)
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


            var getCommentResult = this.serviceComment.GetWithAuthor(addCommentResult.Data);
            return getCommentResult;
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