using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    public class JobOfferDetailViewModel
    {
        public long Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferDetailViewModel_JobOfferText")]
        public string JobOfferText { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferDetailViewModel_Position")]
        public string Position { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferDetailViewModel_Salary")]
        public decimal Salary { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferDetailViewModel_CompanyName")]
        public string CompanyName { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferDetailViewModel_Requirements")]
        public string Requirements { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferDetailViewModel_OfferMatchesProfile")]
        public bool OfferMatchesProfile { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferDetailViewModel_ProfileWasReadBeforeSending")]
        public bool ProfileWasReadBeforeSending { get; set; }

        public JobOfferStatus Status { get; set; }

        public long DeveloperId { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferDetailViewModel_DeveloperDisplayName")]
        public string DeveloperDisplayName { get; set; }

        public List<JobOfferCommentViewModel> JobOfferComments { get; set; }
        public List<JobOfferStatusChangeViewModel> JobOfferStatusChangeViewModels { get; set; }
    }
}