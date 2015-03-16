namespace DreamJob.Services
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using AutoMapper;

    using DreamJob.Dtos;
    using DreamJob.Infrastructure;
    using DreamJob.Models;
    using DreamJob.ViewModels;

    public class CommentService : ICommentService
    {
        private readonly IAccountService authentication;

        private readonly ApplicationDatabase applicationDatabase;

        public CommentService(IAccountService authentication, ApplicationDatabase applicationDatabase)
        {
            this.authentication = authentication;
            this.applicationDatabase = applicationDatabase;
        }

        public long Add(CommentAddDto dto)
        {
            var currentUserId = this.authentication.GetCurrentLoggedUserId();
            var currentUserRole = this.authentication.GetCurrentLoggedUserRole();
            var model = Mapper.Map<CommentAddDto, JobOfferComment>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorRole = currentUserRole;
            model.AuthorId = currentUserId;

            var jobOfferModel = this.applicationDatabase.JobOffers.First(joboffer => joboffer.Id == dto.JobOfferId);
            var destinationUserId = currentUserRole == ApplicationUserRole.Developer
                                        ? jobOfferModel.RecruiterId
                                        : jobOfferModel.DeveloperId;
            var newMessage = new NewMessageToRead(
                destinationUserId,
                dto.JobOfferId,
                ApplicationMessageType.Comment);
            newMessage.CreateDateTime = DateTime.Now;
            this.applicationDatabase.NewMessagesToRead.Add(newMessage);

            this.applicationDatabase.JobOffersComments.Add(model);
            this.applicationDatabase.SaveChanges();
            return model.Id;
        }

        public JobOfferCommentViewModel AddAndGetViewModelForCurrentUser(CommentAddDto dto)
        {
            var newCommentId = this.Add(dto);
            var commentModel =
                this.applicationDatabase.JobOffersComments.Include(c => c.Author)
                    .Include(c => c.Author.Recruiter)
                    .Include(c => c.Author.Developer)
                    .First(comment => comment.Id == newCommentId);
            var viewmodel = Mapper.Map<JobOfferComment, JobOfferCommentViewModel>(commentModel);
            var currentLoggedUserRole = this.authentication.GetCurrentLoggedUserRole();
            if (currentLoggedUserRole == ApplicationUserRole.Developer)
            {
                viewmodel.AuthorDisplayName = commentModel.Author.Developer.DisplayName;
            }
            else
            {
                viewmodel.AuthorDisplayName = string.Format(
                    "{0} {1}",
                    commentModel.Author.Recruiter.FirstName,
                    commentModel.Author.Recruiter.LastName);
            }

            return viewmodel;
        }
    }
}