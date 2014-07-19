namespace DreamJob.Model.Domain
{
    using System;
    using System.Collections.Generic;

    public class CompanyExperience : BaseEntity
    {
        public Company Employer { get; set; }
        public long EmployerId { get; set; }
        public WorkPosition Position { get; set; }
        public long PositionId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public List<Developer> Developers { get; set; }
    }
}