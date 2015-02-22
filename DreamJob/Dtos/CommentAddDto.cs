namespace DreamJob.Dtos
{
    using DreamJob.ViewModels;

    public class CommentAddDto
    {
        public long JobOfferId { get; set; }
        public string Text { get; set; }
        public JobOfferStatus Status { get; set; }
    }
}