namespace DreamJob.Models
{
    using DreamJob.ViewModels;

    public class JobOfferStatusChange : DJDbBase
    {
        public JobOfferStatusChange():this(-1,JobOfferStatus.None,string.Empty, -1, ApplicationUserRole.Anonymous)
        {}

        public JobOfferStatusChange(
            long jobOfferId,
            JobOfferStatus status,
            string text,
            long authorId,
            ApplicationUserRole authorRole)
        {
            this.JobOfferId = jobOfferId;
            this.Status = status;
            this.Text = text;
            this.AuthorId = authorId;
            this.AuthorRole = authorRole;
        }

        public long JobOfferId { get; set; }
        public string Text { get; set; }

        public long AuthorId { get; set; }
        public ApplicationUserRole AuthorRole { get; set; }

        public JobOfferStatus Status { get; set; }

        public virtual ContactInformation ContactInformation { get; set; }

    }
}