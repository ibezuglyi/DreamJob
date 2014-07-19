namespace DreamJob.Model.Domain
{
    using System.Collections.Generic;

    public class Developer : User
    {
        public long DeveloperId { get; set; }
        public long UserId { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectExperience> ProjectExperiences { get; set; }
        public List<CompanyExperience> CompanyExperiences { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}