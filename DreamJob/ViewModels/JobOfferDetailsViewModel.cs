namespace DreamJob.ViewModels
{
    public class JobOfferDetailsViewModel
    {
        public JobOfferDetailViewModel JobOfferDetailViewModel { get; set; }
        public JobOfferNewCommentViewModel NewCommentViewModel { get; set; }

        public JobOfferDetailsViewModel(JobOfferDetailViewModel jobOfferDetailViewModel)
        {
            this.JobOfferDetailViewModel = jobOfferDetailViewModel;
            this.NewCommentViewModel = new JobOfferNewCommentViewModel();
        }
    }
}