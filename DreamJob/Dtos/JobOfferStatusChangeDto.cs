namespace DreamJob.Dtos
{
    using DreamJob.Models;
    using DreamJob.ViewModels;

    public class JobOfferStatusChangeDto
    {
        public long JobOfferId { get; set; }
        public JobOfferStatus Status { get; set; }
        public string Text { get; set; }
        public ContactInformation ContactInformation { get; set; }
    }
}