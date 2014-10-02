namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface ICommentBusiness
    {
        DjOperationResult<JobOfferCommentDto> AddNewComment(long offerId, string text, string loginUrl);
    }
}