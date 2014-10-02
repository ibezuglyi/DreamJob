namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    public interface ICommentsRepository
    {
        DjOperationResult<long> InsertComment(JobOfferComment jobOfferComment);
        DjOperationResult<JobOfferComment> GetCommentWithAuthor(long commentId);
    }
}