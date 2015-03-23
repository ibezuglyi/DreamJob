namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    public class JobOfferCommentsViewModel
    {
        public JobOfferCommentsViewModel()
            : this(new List<JobOfferCommentViewModel>())
        { }

        public JobOfferCommentsViewModel(List<JobOfferCommentViewModel> comments)
        {
            this.Comments = comments;
        }

        public List<JobOfferCommentViewModel> Comments { get; set; }
    }
}