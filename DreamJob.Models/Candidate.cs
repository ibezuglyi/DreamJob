using System.Collections.Generic;

namespace DreamJob.Models
{
    public class Candidate : User
    {
        public List<Experience> WorkExperience { get; set; }
        public List<Experience> EducationExperience { get; set; }
        public List<JobRequirement> JobRequirements { get; set; }
        public List<Tag> NotInterested { get; set; }

        public string AboutMe { get; set; }
    }
}
