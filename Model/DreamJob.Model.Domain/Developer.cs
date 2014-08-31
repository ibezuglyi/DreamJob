namespace DreamJob.Model.Domain
{
    using System.Collections.Generic;

    public class Developer : User
    {
        public Developer()
        {
            this.Skills = new List<Skill>();
            this.JobOffersReceived = new List<JobOffer>();
        }
        
        public string Title { get; set; }
        public string Profile { get; set; }
        public string ProjectPreferences { get; set; }
        public long MinSalary { get; set; }
        public string City { get; set; }
        public List<Skill> Skills { get; set; }
        public List<JobOffer> JobOffersReceived { get; set; }
    }
}