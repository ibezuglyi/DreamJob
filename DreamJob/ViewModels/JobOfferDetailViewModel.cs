namespace DreamJob.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class JobOfferDetailViewModel
    {
        public long Id { get; set; }

        public DateTime CreateDateTime { get; set; }
        public string JobOfferText { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string CompanyName { get; set; }
        public string Requirements { get; set; }
        public bool OfferMatchesProfile { get; set; }
        public bool ProfileWasReadBeforeSending { get; set; }
        public JobOfferStatus Status { get; set; }

        public long DeveloperId { get; set; }
        public string DeveloperDisplayName { get; set; }

        public List<JobOfferCommentViewModel> JobOfferComments { get; set; }
        public List<JobOfferStatusChangeViewModel> JobOfferStatusChangeViewModels { get; set; }
    }
}