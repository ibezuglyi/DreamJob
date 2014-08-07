namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    public interface ICommentsRepository
    {
        DjOperationResult<long> Insert(JobOfferComment jobOfferComment);
    }

    public class CommentsRepository : ICommentsRepository
    {
        private readonly DreamJobContext context;

        public CommentsRepository(DreamJobContext context)
        {
            this.context = context;
        }

        public DjOperationResult<long> Insert(JobOfferComment jobOfferComment)
        {
            this.context.JobOffersComments.Add(jobOfferComment);
            this.context.SaveChanges();

            var insertResult = new DjOperationResult<long>(jobOfferComment.Id);
            return insertResult;
        }
    }
}