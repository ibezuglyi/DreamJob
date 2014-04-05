namespace DreamJob.Domain.Models
{
    public class JobOffer : BaseEntity
    {
        public Recruiter Ofereer { get; set; }
        public Candidate Oferee { get; set; }
        public JobOfferStatus JobOfferStatus { get; set; }

        public string Description { get; set; }
        public string Feedback { get; set; }
    }
}