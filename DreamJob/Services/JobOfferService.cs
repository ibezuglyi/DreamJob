namespace DreamJob.Services
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
                    .Include(o => o.Statuses)
                    .Include(o => o.NewMessagesToRead)
                    .First(o => o.Id == id);


            var newMessagesForMe =
                model.NewMessagesToRead.Where(message => message.UserAccountId == currentLoggedUserId).ToList();
            newMessagesForMe.Each(m => this.applicationDatabase.NewMessagesToRead.Remove(m));
            this.applicationDatabase.SaveChanges();

            var developerComment =
                model.JobOfferComments.FirstOrDefault(comment => comment.AuthorRole == ApplicationUserRole.Developer);
            var recruiterComment =
                model.JobOfferComments.FirstOrDefault(comment => comment.AuthorRole == ApplicationUserRole.Recruiter);

            Developer developerModel = this.applicationDatabase.Developers.First(d => d.Id == model.DeveloperId);
            Recruiter recruiterModel = this.applicationDatabase.Recruiters.First(d => d.Id == model.RecruiterId);

            var jobOfferDetailViewModel = Mapper.Map<JobOffer, JobOfferDetailViewModel>(model);

            jobOfferDetailViewModel.JobOfferComments
                .Where(c => c.AuthorRole == ApplicationUserRole.Developer)
                .Each(c => c.AuthorDisplayName = developerModel.DisplayName);

            jobOfferDetailViewModel.JobOfferComments
                .Where(c => c.AuthorRole == ApplicationUserRole.Recruiter)
                .Each(c => c.AuthorDisplayName = string.Format("{0} {1}", recruiterModel.FirstName, recruiterModel.LastName));

            jobOfferDetailViewModel.JobOfferStatusChangeViewModels
                .Where(s => s.AuthorRole == ApplicationUserRole.Recruiter)
                .Each(s => s.AuthorName = string.Format("{0} {1}", recruiterModel.FirstName, recruiterModel.LastName));

            jobOfferDetailViewModel.JobOfferStatusChangeViewModels
                .Where(s => s.AuthorRole == ApplicationUserRole.Developer)
                .Each(s => s.AuthorName = developerModel.DisplayName);


            var result = new JobOfferDetailsViewModel(jobOfferDetailViewModel);

            var currentStatus = model.Statuses.OrderByDescending(s => s.CreateDateTime).First().Status;
            var actions = this.GetOfferActionsForRoleAndOfferStatus(currentUserRole, currentStatus);

            result.NewCommentViewModel = new JobOfferNewCommentViewModel(id, actions);
            return result;
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
            var viemwodel = new JobOfferAcceptViewModel(id);
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
            var model = Mapper.Map<JobOfferAcceptDto, JobOfferStatusChange>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();
            model.ContactInformation.CreateDateTime = DateTime.Now;
            model.ContactInformation.JobOfferStatusChangeId = model.Id;
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