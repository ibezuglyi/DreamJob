namespace DreamJob.ViewModels
{
    using System;

    public class JobOfferStatusChangeViewModel
    {
        public long Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Text { get; set; }
        public JobOfferStatus Status { get; set; }

        public long AuthorId { get; set; }

        public ApplicationUserRole AuthorRole { get; set; }

        public string GetStatusClass()
        {
            return string.Format("status-{0}", Status.ToString().ToLower());
        }
    }
}