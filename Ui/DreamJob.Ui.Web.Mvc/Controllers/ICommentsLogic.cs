namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface ICommentsLogic
    {
        DjOperationResult<JobOfferCommentDto> AddNewComment(long offerId, string text);
    }
}