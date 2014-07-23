namespace DreamJob.Model.Domain
{
    using System.Collections.Generic;

    public class Recruiter : User
    {
        public long RecruiterId { get; set; }
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public Company CurrentEmployer { get; set; }
        public long CurrentEmployerId { get; set; }
        public List<Feedback> Feedbacks { get; set; }
        public List<JobOffer> JobOffersSent { get; set; }
    }
}