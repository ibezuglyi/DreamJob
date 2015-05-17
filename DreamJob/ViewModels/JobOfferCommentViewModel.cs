using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using System;

    public class JobOfferCommentViewModel
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferCommentViewModel_Text")]
        public string Text { get; set; }

        public ApplicationUserRole AuthorRole { get; set; }
        public long AuthorId { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferCommentViewModel_AuthorDisplayName")]
        public string AuthorDisplayName { get; set; }
    }
}