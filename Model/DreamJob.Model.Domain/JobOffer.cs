namespace DreamJob.Model.Domain
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;

    public class JobOffer : BaseEntity
    {
        public JobOffer()
        {
            this.JobOfferComments = new List<JobOfferComment>();
        }

        public Recruiter FromRecruiter { get; set; }
        public long FromRecruiterId { get; set; }
        public Developer ToDeveloper { get; set; }
        public long ToDeveloperId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public OfferStatus OfferStatus { get; set; }
        public long MinSalary { get; set; }
        public long? MaxSalary { get; set; }
        public bool MatchesDeveloperRequirements { get; set; }
        public List<JobOfferComment> JobOfferComments { get; set; }
    }
}