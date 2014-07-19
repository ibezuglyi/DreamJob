namespace DreamJob.Model.Domain
{
    using System.Collections.Generic;

    using DreamJob.Model.Domain.Enum;

    public class JobOffer : BaseEntity
    {
        public Recruiter From { get; set; }
        public long FromId { get; set; }
        public Developer To { get; set; }
        public long ToId { get; set; }
        public string Description { get; set; }
        public OfferStatus OfferStatus { get; set; }
        public Company TargetCompany { get; set; }
        public long TargetCompanyId { get; set; }
        public WorkPosition TargetWorkPosition { get; set; }
        public long TargetWorkPositionId { get; set; }
        public SalaryRange SalaryRange { get; set; }
        public long SalaryRangeId { get; set; }
        public List<Skill> RequiredSkills { get; set; }
    }
}