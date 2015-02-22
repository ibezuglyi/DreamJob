namespace DreamJob.Models
{
    using DreamJob.ViewModels;

    public class JobOfferCancel : DJDbBase
    {
        public long JobOfferId { get; set; }
        public string Text { get; set; }
        public long AuthorId { get; set; }
        public ApplicationUserRole AuthorRole { get; set; }
    }
}