namespace DreamJob.Models
{
    using System.Collections.Generic;

    using DreamJob.ViewModels;

    public class JobOffer : DJDbBase
    {
        public string JobOfferText { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string CompanyName { get; set; }
        public string Requirements { get; set; }
        public bool OfferMatchesProfile { get; set; }
        public bool ProfileWasReadBeforeSending { get; set; }

        public JobOfferStatus Status { get; set; }

        public long DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }

        public long RecruiterId { get; set; }
        public virtual Recruiter Recruiter { get; set; }

        public virtual List<JobOfferComment> JobOfferComments { get; set; }

        public virtual List<JobOfferAccept> Accepts { get; set; }
        public virtual List<JobOfferReject> Rejects { get; set; }
        public virtual List<JobOfferCancel> Cancels { get; set; }
        public virtual List<JobOfferConfirm> Confirms { get; set; }
    }
}