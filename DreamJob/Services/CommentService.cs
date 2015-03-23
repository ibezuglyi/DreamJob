﻿namespace DreamJob.Services
{
    using System;
    using System.Collections.Generic;
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

        public JobOfferCommentsViewModel GetNewComments(long jobOfferId, int commentsCount)
        {
            var models =
                this.applicationDatabase.JobOffersComments.Include(c => c.Author)
                    .Include(c => c.Author.Developer)
                    .Include(c => c.Author.Recruiter)
                    .OrderBy(c => c.CreateDateTime)
                    .Where(c => c.JobOfferId == jobOfferId)
                    .Skip(commentsCount)
                    .ToList();
            var viewmodel = Mapper.Map<List<JobOfferComment>, List<JobOfferCommentViewModel>>(models);
            var result = new JobOfferCommentsViewModel(viewmodel);
            return result;
        }

    }
}