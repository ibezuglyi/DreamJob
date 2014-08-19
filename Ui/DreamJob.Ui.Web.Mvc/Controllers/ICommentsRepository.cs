namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    public interface ICommentsRepository
    {
        DjOperationResult<long> Insert(JobOfferComment jobOfferComment);
        DjOperationResult<JobOfferComment> GetWithAuthor(long commentId);
    }
}