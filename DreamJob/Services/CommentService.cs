namespace DreamJob.Services
{
    using System;

    using DreamJob.Dtos;
    using DreamJob.Infrastructure;
    using DreamJob.Models;

    public class CommentService : ICommentService
    {
        private readonly IAuthentication authentication;
        private readonly ApplicationDatabase applicationDatabase;

        public CommentService(IAuthentication authentication, ApplicationDatabase applicationDatabase)
        {
            this.authentication = authentication;
            this.applicationDatabase = applicationDatabase;
        }

        public void Add(CommentAddDto dto)
        {
            var currentUserId = this.authentication.GetCurrentLoggedUserId();
            var currentUserRole = this.authentication.GetCurrentLoggedUserRole();
            var model = AutoMapper.Mapper.Map<CommentAddDto, JobOfferComment>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorRole= currentUserRole;
            model.AuthorId = currentUserId;

            this.applicationDatabase.JobOffersComments.Add(model);
            this.applicationDatabase.SaveChanges();
        }
    }
}