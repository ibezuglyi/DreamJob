namespace DreamJob.Services
{
    using DreamJob.Dtos;

    public interface ICommentService
    {
        void Add(CommentAddDto dto);
    }
}