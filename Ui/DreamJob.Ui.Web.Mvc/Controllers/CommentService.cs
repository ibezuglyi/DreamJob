namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Helpers;

    public class CommentService : ICommentService
    {
        private readonly IDateTimeAdapter adapterDateTime;

        private readonly ICommentsRepository repositoryComments;

        public CommentService(IDateTimeAdapter adapterDateTime, ICommentsRepository repositoryComments)
        {
            this.adapterDateTime = adapterDateTime;
            this.repositoryComments = repositoryComments;
        }

        public DjOperationResult<long> AddNewComment(long offerId, string text, long authorId)
        {
            var jobOfferComment = new JobOfferComment
                                      {
                                          AuthorId = authorId,
                                          Add = this.adapterDateTime.Now,
                                          Edit = this.adapterDateTime.Now,
                                          JobOfferId = offerId,
                                          Status = JobOfferCommentStatus.New,
                                          Text = text
                                      };

            var insertResult = this.repositoryComments.Insert(jobOfferComment);
            return insertResult;
        }
    }
}