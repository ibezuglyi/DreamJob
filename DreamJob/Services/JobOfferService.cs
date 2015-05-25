﻿namespace DreamJob.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using AutoMapper;

    using Dtos;
    using Infrastructure;
    using Models;
    using ViewModels;

    class JobOfferService : IJobOfferService
    {
        private readonly IAccountService authentication;

        private readonly ApplicationDatabase applicationDatabase;

        public JobOfferService(IAccountService authentication, ApplicationDatabase applicationDatabase)
        {
            this.authentication = authentication;
            this.applicationDatabase = applicationDatabase;
        }

        public void Add(JobOfferSendDto dto)
        {
            var authorId = this.authentication.GetCurrentLoggedUserId();
            var model = Mapper.Map<JobOfferSendDto, JobOffer>(dto);
            model.RecruiterId = authorId;
            model.CreateDateTime = DateTime.Now;
            var josc = new JobOfferStatusChange(
                model.Id,
                JobOfferStatus.New,
                string.Empty,
                authorId,
                this.authentication.GetCurrentLoggedUserRole());

            josc.CreateDateTime = DateTime.Now;

            this.applicationDatabase.JobOffers.Add(model);
            this.applicationDatabase.JobOfferStatusChanges.Add(josc);

            var newMessage = new NewMessageToRead(dto.DeveloperId, model.Id, ApplicationMessageType.JobOffer);
            newMessage.CreateDateTime = DateTime.Now;

            this.applicationDatabase.NewMessagesToRead.Add(newMessage);

            this.applicationDatabase.SaveChanges();
        }

        public JobOfferIndexViewModel GetJobOffers()
        {
            var currentRole = this.authentication.GetCurrentLoggedUserRole();
            var currentUserId = this.authentication.GetCurrentLoggedUserId();

            List<JobOffer> offers;
            var jobOffers = this.applicationDatabase
                    .JobOffers
                    .Include(d => d.NewMessagesToRead)
                    .Include(d => d.Statuses)
                    .Include(d => d.Developer);

            if (currentRole == ApplicationUserRole.Recruiter)
            {
                offers = jobOffers
                    .Where(o => o.RecruiterId == currentUserId).ToList();
            }
            else
            {
                offers = jobOffers.Where(o => o.DeveloperId == currentUserId).ToList();
            }

            var offersList = Mapper.Map<List<JobOffer>, List<JobOfferHeadlineViewModel>>(offers);
            offersList.ForEach(
                offer =>
                offer.MessagesCount =
                jobOffers.First(model => model.Id == offer.Id)
                    .NewMessagesToRead.Count(message => message.UserAccountId == currentUserId));
            var viewmodel = new JobOfferIndexViewModel(offersList);
            return viewmodel;
        }

        public JobOfferDetailsViewModel GetDetailsById(long id)
        {
            var currentUserRole = this.authentication.GetCurrentLoggedUserRole();
            var currentLoggedUserId = this.authentication.GetCurrentLoggedUserId();
            var model =
                this.applicationDatabase
                    .JobOffers
                    .Include(o => o.Developer)
                    .Include(o => o.JobOfferComments)
                    .Include(o => o.JobOfferComments.Select(c => c.Author))
                    .Include(o => o.JobOfferComments.Select(c => c.Author.Developer))
                    .Include(o => o.JobOfferComments.Select(c => c.Author.Recruiter))
                    .Include(o => o.Statuses)
                    .Include(o => o.NewMessagesToRead)
                    .First(o => o.Id == id);

            if (currentUserRole == ApplicationUserRole.Developer && model.DeveloperId != currentLoggedUserId)
            {
                return null;
            }
            if (currentUserRole == ApplicationUserRole.Recruiter && model.RecruiterId != currentLoggedUserId)
            {
                return null;
            }

            var newMessagesForMe =
                model.NewMessagesToRead.Where(message => message.UserAccountId == currentLoggedUserId).ToList();
            newMessagesForMe.Each(m => this.applicationDatabase.NewMessagesToRead.Remove(m));
            this.applicationDatabase.SaveChanges();

            Developer developerModel = this.applicationDatabase.Developers.First(d => d.Id == model.DeveloperId);
            Recruiter recruiterModel = this.applicationDatabase.Recruiters.First(d => d.Id == model.RecruiterId);

            var jobOfferDetailViewModel = Mapper.Map<JobOffer, JobOfferDetailViewModel>(model);

            UpdateJobOfferDetailViewModelWithRoles(jobOfferDetailViewModel, recruiterModel, developerModel, currentLoggedUserId);
            var result = GetJobOfferDetailsViewModel(id, jobOfferDetailViewModel, model, currentUserRole);
            return result;
        }

        private JobOfferDetailsViewModel GetJobOfferDetailsViewModel(long id, JobOfferDetailViewModel jobOfferDetailViewModel, JobOffer model, ApplicationUserRole currentUserRole)
        {
            var result = new JobOfferDetailsViewModel(jobOfferDetailViewModel);

            var currentStatus = model.Statuses.OrderByDescending(s => s.CreateDateTime).First().Status;
            var actions = this.GetOfferActionsForRoleAndOfferStatus(currentUserRole, currentStatus);

            result.NewCommentViewModel = new JobOfferNewCommentViewModel(id, actions);
            return result;
        }

        private static void UpdateJobOfferDetailViewModelWithRoles(JobOfferDetailViewModel jobOfferDetailViewModel,
            Recruiter recruiterModel, Developer developerModel, long currentLoggedUserId)
        {
            jobOfferDetailViewModel.JobOfferStatusChangeViewModels
                .Where(s => s.AuthorRole == ApplicationUserRole.Recruiter)
                .Each(s => s.AuthorName = string.Format("{0} {1}", recruiterModel.FirstName, recruiterModel.LastName));

            jobOfferDetailViewModel.JobOfferStatusChangeViewModels
                .Where(s => s.AuthorRole == ApplicationUserRole.Developer)
                .Each(s => s.AuthorName = developerModel.DisplayName);
            jobOfferDetailViewModel.JobOfferComments.Each(c => c.IsCurrentUserComment = c.AuthorId == currentLoggedUserId);
        }

        public JobOfferRejectViewModel GetJobOfferRejectViewModel(long id)
        {
            var viemwodel = new JobOfferRejectViewModel(id);
            return viemwodel;
        }

        public JobOfferCancelViewModel GetJobOfferCancelViewModel(long id)
        {
            var viemwodel = new JobOfferCancelViewModel(id);
            return viemwodel;
        }

        public JobOfferAcceptViewModel GetJobOfferAcceptViewModel(long id)
        {
            var offer = applicationDatabase.JobOffers.First(r => r.Id == id);
            var viemwodel = new JobOfferAcceptViewModel(id, offer.CompanyName, offer.Position, offer.Salary);
            return viemwodel;
        }
        public JobOfferAcceptViewModel GetJobOfferAcceptViewModel(JobOfferAcceptDto dto)
        {
            var offer = applicationDatabase.JobOffers.First(r => r.Id == dto.JobOfferId);
            var viemwodel = new JobOfferAcceptViewModel(dto, offer.CompanyName, offer.Position, offer.Salary);
            return viemwodel;
        }

        public JobOfferConfirmViewModel GetJobOfferConfirmViewModel(long id)
        {
            var viemwodel = new JobOfferConfirmViewModel(id);
            return viemwodel;
        }

        public void RejectOffer(JobOfferRejectDto dto)
        {
            var model = Mapper.Map<JobOfferRejectDto, JobOfferStatusChange>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();
            this.applicationDatabase.JobOfferStatusChanges.Add(model);

            var jobOfferModel = this.applicationDatabase.JobOffers.First(joboffer => joboffer.Id == dto.JobOfferId);
            var newMessage = new NewMessageToRead(
                jobOfferModel.RecruiterId,
                dto.JobOfferId,
                ApplicationMessageType.Status);
            newMessage.CreateDateTime = DateTime.Now;
            this.applicationDatabase.NewMessagesToRead.Add(newMessage);

            this.applicationDatabase.SaveChanges();
        }

        public void CancelOffer(JobOfferCancelDto dto)
        {
            var model = Mapper.Map<JobOfferCancelDto, JobOfferStatusChange>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();
            this.applicationDatabase.JobOfferStatusChanges.Add(model);

            var jobOfferModel = this.applicationDatabase.JobOffers.First(jobOffer => jobOffer.Id == dto.JobOfferId);

            var newMessage = new NewMessageToRead(
                jobOfferModel.DeveloperId,
                dto.JobOfferId,
                ApplicationMessageType.Status);
            newMessage.CreateDateTime = DateTime.Now;

            this.applicationDatabase.NewMessagesToRead.Add(newMessage);
            this.applicationDatabase.SaveChanges();
        }

        public void AcceptOffer(JobOfferAcceptDto dto)
        {
            UpdateJobOfferStatus(dto);
            AddNewMessageToRead(dto);
            this.applicationDatabase.SaveChanges();
        }

        private void AddNewMessageToRead(JobOfferAcceptDto dto)
        {
            var jobOfferModel = this.applicationDatabase.JobOffers.First(joboffer => joboffer.Id == dto.JobOfferId);
            var newMessage = new NewMessageToRead(jobOfferModel.RecruiterId, dto.JobOfferId, ApplicationMessageType.Status);
            newMessage.CreateDateTime = DateTime.Now;
            this.applicationDatabase.NewMessagesToRead.Add(newMessage);
        }

        private void UpdateJobOfferStatus(JobOfferAcceptDto dto)
        {
            var model = Mapper.Map<JobOfferAcceptDto, JobOfferStatusChange>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();
            model.ContactInformation.CreateDateTime = DateTime.Now;
            model.ContactInformation.JobOfferStatusChangeId = model.Id;
            this.applicationDatabase.JobOfferStatusChanges.Add(model);
        }

        public void ConfirmOffer(JobOfferConfirmDto dto)
        {
            var model = Mapper.Map<JobOfferConfirmDto, JobOfferStatusChange>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();
            this.applicationDatabase.JobOfferStatusChanges.Add(model);

            var jobOfferModel = this.applicationDatabase.JobOffers.First(joboffer => joboffer.Id == dto.JobOfferId);
            var newMessage = new NewMessageToRead(
                jobOfferModel.RecruiterId,
                dto.JobOfferId,
                ApplicationMessageType.Status);
            newMessage.CreateDateTime = DateTime.Now;
            this.applicationDatabase.NewMessagesToRead.Add(newMessage);

            this.applicationDatabase.SaveChanges();
        }

        public void ChangeStatus(JobOfferStatusChangeDto dto)
        {
            switch (dto.Status)
            {
                case JobOfferStatus.Rejected:
                    var rejectDto = Mapper.Map<JobOfferStatusChangeDto, JobOfferRejectDto>(dto);
                    this.RejectOffer(rejectDto);
                    break;
                case JobOfferStatus.Canceled:
                    var cancelDto = Mapper.Map<JobOfferStatusChangeDto, JobOfferCancelDto>(dto);
                    this.CancelOffer(cancelDto);
                    break;
                case JobOfferStatus.Accepted:
                    var acceptDto = Mapper.Map<JobOfferStatusChangeDto, JobOfferAcceptDto>(dto);
                    this.AcceptOffer(acceptDto);
                    break;
                case JobOfferStatus.Confirmed:
                    var confirmDto = Mapper.Map<JobOfferStatusChangeDto, JobOfferConfirmDto>(dto);
                    this.ConfirmOffer(confirmDto);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

        }

        public JobOfferContactDetailsViewModel GetContactDetailsById(long id)
        {
            var model = this.applicationDatabase
                .ContactInformations
                .Include(c => c.JobOfferStatusChange)
                .First(c => c.Id == id);
            var ciViewModel = Mapper.Map<ContactInformation, ContactInformationViewModel>(model);
            var result = new JobOfferContactDetailsViewModel(ciViewModel);
            return result;
        }



        private List<JobOfferStatus> GetOfferActionsForRoleAndOfferStatus(
            ApplicationUserRole currentUserRole,
            JobOfferStatus status)
        {
            if (currentUserRole == ApplicationUserRole.Developer)
            {
                return this.GetOfferActionsForDeveloperByOfferStatus(status);
            }
            if (currentUserRole == ApplicationUserRole.Recruiter)
            {
                return this.GetOfferActionsForRecruiterByOfferStatus(status);
            }
            throw new ArgumentOutOfRangeException("currentUserRole");

        }

        private List<JobOfferStatus> GetOfferActionsForRecruiterByOfferStatus(JobOfferStatus status)
        {
            var result = new List<JobOfferStatus>();
            switch (status)
            {
                case JobOfferStatus.New:
                case JobOfferStatus.Read:
                case JobOfferStatus.Accepted:
                case JobOfferStatus.Confirmed:
                case JobOfferStatus.Rejected:
                    result.Add(JobOfferStatus.Canceled);
                    break;
                case JobOfferStatus.Canceled:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("JobOfferStatus");
            }
            return result;
        }

        private List<JobOfferStatus> GetOfferActionsForDeveloperByOfferStatus(JobOfferStatus status)
        {
            var result = new List<JobOfferStatus>();
            switch (status)
            {
                case JobOfferStatus.New:
                case JobOfferStatus.Read:
                    result.Add(JobOfferStatus.Rejected);
                    result.Add(JobOfferStatus.Accepted);
                    break;
                case JobOfferStatus.Rejected:
                    result.Add(JobOfferStatus.Accepted);
                    result.Add(JobOfferStatus.Confirmed);
                    break;
                case JobOfferStatus.Canceled:
                    break;
                case JobOfferStatus.Accepted:
                    result.Add(JobOfferStatus.Rejected);
                    result.Add(JobOfferStatus.Confirmed);
                    break;
                case JobOfferStatus.Confirmed:
                    result.Add(JobOfferStatus.Rejected);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("JobOfferStatus");
            }
            return result;
        }
    }
}