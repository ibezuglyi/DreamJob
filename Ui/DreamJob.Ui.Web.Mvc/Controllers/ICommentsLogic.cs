namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface ICommentsLogic
    {
        DjOperationResult<long> AddNewComment(long offerId, string text);
    }
}