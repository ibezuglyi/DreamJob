namespace DreamJob.ViewModels
{
    using System;

    public class JobOfferCommentViewModel
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Text { get; set; }
        public ApplicationUserRole AuthorRole { get; set; }
        public long AuthorId { get; set; }
        public string AuthorDisplayName { get; set; }
    }
}