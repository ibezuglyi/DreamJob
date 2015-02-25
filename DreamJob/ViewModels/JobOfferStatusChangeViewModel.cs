namespace DreamJob.ViewModels
{
    using System;

    public class JobOfferStatusChangeViewModel
    {
        public string AuthorName { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Text { get; set; }
        public JobOfferStatus Status { get; set; }

        public long AuthorId { get; set; }

        public ApplicationUserRole AuthorRole { get; set; }
    }
}