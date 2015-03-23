namespace DreamJob.Services
{
    using DreamJob.Dtos;
    using DreamJob.ViewModels;

    public interface ICommentService
    {
        long Add(CommentAddDto dto);
        JobOfferCommentsViewModel GetNewComments(long jobOfferId, int commentsCount);
    }
}