namespace DreamJob.Models
{
    using System.Collections.Generic;

    public class JobOffer : DJDbBase
    {
        public JobOffer()
        {
            this.JobOfferComments = new List<JobOfferComment>();
            this.Statuses = new List<JobOfferStatusChange>();
            this.NewMessagesToRead = new List<NewMessageToRead>();
        }

        public string JobOfferText { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string CompanyName { get; set; }
        public string Requirements { get; set; }
        public bool OfferMatchesProfile { get; set; }
        public bool ProfileWasReadBeforeSending { get; set; }

        public long DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }

        public long RecruiterId { get; set; }
        public virtual Recruiter Recruiter { get; set; }

        public virtual List<JobOfferComment> JobOfferComments { get; set; }
        public virtual List<JobOfferStatusChange> Statuses { get; set; }
        public virtual List<NewMessageToRead> NewMessagesToRead { get; set; }
    }
}