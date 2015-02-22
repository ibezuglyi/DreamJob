namespace DreamJob.Models
{
    using DreamJob.ViewModels;

    public class JobOfferComment : DJDbBase
    {
        public long AuthorId { get; set; }
        public ApplicationUserRole AuthorRole { get; set; }
        public string Text { get; set; }

        public long JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}