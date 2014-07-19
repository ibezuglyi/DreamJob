namespace DreamJob.Model.Domain
{
    using System;
    using System.Collections.Generic;

    public class ProjectExperience : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public List<Skill> Skills { get; set; }
    }
}