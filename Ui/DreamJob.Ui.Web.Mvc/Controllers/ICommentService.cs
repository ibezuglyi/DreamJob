namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface ICommentService
    {
        DjOperationResult<long> AddNewComment(long offerId, string text, long authorId);
    }
}