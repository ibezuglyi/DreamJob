namespace DreamJob.Services
{
    using DreamJob.Dtos;
    using DreamJob.ViewModels;

    public interface ICommentService
    {
        long Add(CommentAddDto dto);
        JobOfferCommentViewModel AddAndGetViewModelForCurrentUser(CommentAddDto dto);
    }
}