namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System.Data.Entity;
    using System.Linq;

    using DreamJob.Common.Enum;
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

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

        public DjOperationResult<JobOfferComment> GetWithAuthor(long commentId)
        {
            var data = this.context
                .JobOffersComments
                .Include(comment => comment.Author)
                .Single(comment => comment.Id == commentId);
            return new DjOperationResult<JobOfferComment>(data);
        }
    }
}