namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public class CommentsLogic : ICommentsLogic
    {
        private readonly ISession session;

        private readonly ICommentService serviceComment;

        public CommentsLogic(ISession session, ICommentService serviceComment)
        {
            this.session = session;
            this.serviceComment = serviceComment;
        }

        public DjOperationResult<JobOfferCommentDto> AddNewComment(long offerId, string text)
        {
            var getUserResult = this.session.GetCurrentUser();
            if (getUserResult.IsSuccess == false)
            {
                return new DjOperationResult<JobOfferCommentDto>(false, getUserResult.Errors);
            }

            var currentUser = getUserResult.Data;
            var currentUserId = currentUser.Id;

            var addCommentResult = this.serviceComment.AddNewComment(offerId, text, currentUserId);
            if (addCommentResult.IsSuccess == false)
            {
                return new DjOperationResult<JobOfferCommentDto>(false, addCommentResult.Errors);
                
            }

            var getCommentResult = this.serviceComment.GetWithAuthor(addCommentResult.Data);
            return getCommentResult;
        }
    }
}