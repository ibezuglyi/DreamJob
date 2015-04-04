namespace DreamJob.Ui.Web.Mvc.Services
{
    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Helpers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public class CommentService : ICommentService
    {
        private readonly IDateTimeAdapter adapterDateTime;
        private readonly ICommentsRepository commentsRepository;

        public CommentService(IDateTimeAdapter adapterDateTime, ICommentsRepository commentsRepository)
        {
            this.adapterDateTime = adapterDateTime;
            this.commentsRepository = commentsRepository;
        }

        public DjOperationResult<long> AddNewComment(long offerId, string text, long authorId)
        {
            var jobOfferComment = new JobOfferComment(authorId, this.adapterDateTime.Now,this.adapterDateTime.Now,offerId,JobOfferCommentStatus.New,string.IsNullOrEmpty(text) ? string.Empty : text.Trim());
            var insertResult = this.commentsRepository.InsertComment(jobOfferComment);
            return insertResult;
        }

        public DjOperationResult<JobOfferCommentDto> GetCommentWithAuthor(long commentId)
        {
            var getOfferCommentResult = this.commentsRepository.GetCommentWithAuthor(commentId);
            if (getOfferCommentResult.IsSuccess == false)
            {
                return new DjOperationResult<JobOfferCommentDto>(false, getOfferCommentResult.Errors);
            }

            var dtoObject = Mapper.Map<JobOfferComment, JobOfferCommentDto>(getOfferCommentResult.Data);

            var result = new DjOperationResult<JobOfferCommentDto>(dtoObject);
            return result;
        }
    }
}