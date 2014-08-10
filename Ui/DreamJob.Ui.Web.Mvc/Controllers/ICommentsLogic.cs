namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface ICommentsLogic
    {
        DjOperationResult<JobOfferCommentDto> AddNewComment(long offerId, string text);
    }
}