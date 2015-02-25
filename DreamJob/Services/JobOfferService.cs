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
            model.Status = JobOfferStatus.New;

            this.applicationDatabase.JobOffers.Add(model);
            this.applicationDatabase.SaveChanges();
        }

        public JobOfferIndexViewModel GetJobOffers()
        {
            var currentRole = this.authentication.GetCurrentLoggedUserRole();
            var currentUserId = this.authentication.GetCurrentLoggedUserId();

            List<JobOffer> offers;
            var jobOffers = this.applicationDatabase
                    .JobOffers
                    .Include(d => d.Developer);

            if (currentRole == ApplicationUserRole.Recruiter)
            {
                offers = jobOffers.Where(o => o.RecruiterId == currentUserId).ToList();
            }
            else
            {
                offers = jobOffers.Where(o => o.DeveloperId == currentUserId).ToList();
            }

            var offersList = Mapper.Map<List<JobOffer>, List<JobOfferHeadlineViewModel>>(offers);
            var viewmodel = new JobOfferIndexViewModel(offersList);
            return viewmodel;
        }

        public JobOfferDetailsViewModel GetDetailsById(long id)
        {
            var model =
                this.applicationDatabase
                    .JobOffers
                    .Include(o => o.Developer)
                    .Include(o => o.JobOfferComments)
                    .First(o => o.Id == id);

            var developerComment =
                model.JobOfferComments.FirstOrDefault(comment => comment.AuthorRole == ApplicationUserRole.Developer);
            var recruiterComment =
                model.JobOfferComments.FirstOrDefault(comment => comment.AuthorRole == ApplicationUserRole.Recruiter);

            Developer developerModel = null;
            Recruiter recruiterModel = null;

            if (developerComment != null)
            {
                developerModel = this.applicationDatabase.Developers.First(d => d.Id == developerComment.AuthorId);
            }

            if (recruiterComment != null)
            {
                recruiterModel = this.applicationDatabase.Recruiters.First(d => d.Id == recruiterComment.AuthorId);
            }

            var jobOfferDetailViewModel = Mapper.Map<JobOffer, JobOfferDetailViewModel>(model);

            jobOfferDetailViewModel.JobOfferComments
                .Where(c => c.AuthorRole == ApplicationUserRole.Developer)
                .Each(c => c.AuthorDisplayName = developerModel.DisplayName);

            jobOfferDetailViewModel.JobOfferComments
                .Where(c => c.AuthorRole == ApplicationUserRole.Recruiter)
                .Each(c => c.AuthorDisplayName = string.Format("{0} {1}", recruiterModel.FirstName, recruiterModel.LastName));


            var result = new JobOfferDetailsViewModel(jobOfferDetailViewModel);
            var currentUserRole = this.authentication.GetCurrentLoggedUserRole();

            var actions = this.GetOfferActionsForRoleAndOfferStatus(currentUserRole, model.Status);

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
            var model = Mapper.Map<JobOfferRejectDto, JobOfferReject>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();

            var offer = this.applicationDatabase.JobOffers.Single(o => o.Id == dto.JobOfferId);
            offer.Status = JobOfferStatus.Rejected;

            this.applicationDatabase.JobOffersRejections.Add(model);
            this.applicationDatabase.SaveChanges();
        }

        public void CancelOffer(JobOfferCancelDto dto)
        {
            var model = Mapper.Map<JobOfferCancelDto, JobOfferCancel>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();

            var offer = this.applicationDatabase.JobOffers.Single(o => o.Id == dto.JobOfferId);
            offer.Status = JobOfferStatus.Canceled;

            this.applicationDatabase.JobOffersCancels.Add(model);
            this.applicationDatabase.SaveChanges();
        }

        public void AcceptOffer(JobOfferAcceptDto dto)
        {
            var model = Mapper.Map<JobOfferAcceptDto, JobOfferAccept>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();
            model.ContactInformation.CreateDateTime = DateTime.Now;

            var offer = this.applicationDatabase.JobOffers.Single(o => o.Id == dto.JobOfferId);
            offer.Status = JobOfferStatus.Accepted;

            this.applicationDatabase.JobOffersAccepts.Add(model);
            this.applicationDatabase.SaveChanges();
        }

        public void ConfirmOffer(JobOfferConfirmDto dto)
        {
            var model = Mapper.Map<JobOfferConfirmDto, JobOfferConfirm>(dto);
            model.CreateDateTime = DateTime.Now;
            model.AuthorId = this.authentication.GetCurrentLoggedUserId();
            model.AuthorRole = this.authentication.GetCurrentLoggedUserRole();

            var offer = this.applicationDatabase.JobOffers.Single(o => o.Id == dto.JobOfferId);
            offer.Status = JobOfferStatus.Confirmed;

            this.applicationDatabase.JobOffersConfirms.Add(model);
            this.applicationDatabase.SaveChanges();
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