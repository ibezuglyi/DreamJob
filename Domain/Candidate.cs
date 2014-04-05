namespace DreamJob.Domain.Models
{
    using System.Collections.Generic;

    public class Candidate : User
    {
        public Candidate()
        {
            WorkExperience = new List<Experience>();
            EducationExperience = new List<Experience>();
            JobRequirements = new List<JobRequirement>();
            NotInterested = new List<Tag>();
        }

        public List<Experience> WorkExperience { get; set; }
        public List<Experience> EducationExperience { get; set; }
        public List<JobRequirement> JobRequirements { get; set; }
        public List<Tag> NotInterested { get; set; }
        public string AboutMe { get; set; }
    }
}
