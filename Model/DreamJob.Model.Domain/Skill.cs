namespace DreamJob.Model.Domain
{
    using System.Collections.Generic;

    public class Skill : BaseEntity
    {
        public string Name { get; set; }
        public List<Developer> Developers { get; set; }
        public List<ProjectExperience> ProjectExperiences { get; set; }
        public List<JobOffer> JobOffers { get; set; }
    }
}