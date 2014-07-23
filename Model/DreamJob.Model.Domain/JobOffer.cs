namespace DreamJob.Model.Domain
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;

    public class JobOffer : BaseEntity
    {
        public Recruiter FromRecruiter { get; set; }
        public long FromRecruiterId { get; set; }
        public Developer ToDeveloper { get; set; }
        public long ToDeveloperId { get; set; }
        public string Description { get; set; }
        public OfferStatus OfferStatus { get; set; }
        public Company TargetCompany { get; set; }
        public long TargetCompanyId { get; set; }
        public WorkPosition TargetWorkPosition { get; set; }
        public long TargetWorkPositionId { get; set; }
        public SalaryRange SalaryRange { get; set; }
        public long SalaryRangeId { get; set; }
        public List<Skill> RequiredSkills { get; set; }
        public bool MatchesDeveloperRequirements { get; set; }
        public List<JobOfferComment> JobOfferComments { get; set; } 
    }
}