namespace DreamJob.Models
{
    using DreamJob.ViewModels;

    public class JobOfferReject : DJDbBase
    {
        public long AuthorId { get; set; }
        public ApplicationUserRole AuthorRole { get; set; }
        public long JobOfferId { get; set; }
        public string Text { get; set; }
    }
}