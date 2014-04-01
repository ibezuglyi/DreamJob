using System.Collections.Generic;

namespace DreamJob.Models
{
    public class Candidate : User
    {
        public List<Experience> Experiences { get; set; }
        public List<JobRequirement> JobRequirements { get; set; }
    }
}
