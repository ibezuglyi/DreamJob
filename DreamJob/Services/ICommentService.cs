namespace DreamJob.Services
{
    using Dtos;
    using ViewModels;

    public interface ICommentService
    {
        void Add(CommentAddDto dto);
        JobOfferCommentsViewModel GetNewComments(long jobOfferId, int commentsCount);
        void AddByAuthorId(CommentAddDto comment, long authorId);
    }
}