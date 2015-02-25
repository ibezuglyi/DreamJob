namespace DreamJob.Models
{
    using DreamJob.ViewModels;

    public class JobOfferAccept : DJDbBase
    {
        public long JobOfferId { get; set; }
        public string Text { get; set; }

        public long AuthorId { get; set; }
        public ApplicationUserRole AuthorRole { get; set; }

        public long ContactInformationId { get; set; }
        public virtual ContactInformation ContactInformation { get; set; }
    }
}