namespace DreamJob.Services
{
    using System;
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

        public void Add(CommentAddDto dto)
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
        }
    }
}