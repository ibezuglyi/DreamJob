namespace DreamJob.Model.Domain
{
    public class JobOfferComment : BaseEntity
    {
        public JobOffer JobOffer { get; set; }
        public long JobOfferId { get; set; }
        public User Author { get; set; }
        public long AuthorId { get; set; }
        public string Text { get; set; }
        public JobOfferCommentStatus Status { get; set; }
    }
}