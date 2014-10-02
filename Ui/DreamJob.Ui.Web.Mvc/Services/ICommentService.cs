namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface ICommentService
    {
        DjOperationResult<long> AddNewComment(long offerId, string text, long authorId);
        DjOperationResult<JobOfferCommentDto> GetCommentWithAuthor(long commentId);
    }
}