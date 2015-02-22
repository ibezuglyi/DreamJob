namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    public class JobOfferNewCommentViewModel
    {
        public JobOfferNewCommentViewModel()
            : this(0, JobOfferStatus.None)
        { }

        public JobOfferNewCommentViewModel(long id, JobOfferStatus newStatus)
        {
            this.Statuses = new List<JobOfferStatus>()
                                {
                                    JobOfferStatus.Read,
                                    JobOfferStatus.Accepted,
                                    JobOfferStatus.Canceled,
                                    JobOfferStatus.Confirmed,
                                    JobOfferStatus.Rejected
                                };

            this.Text = string.Empty;
            this.Status = newStatus;
            this.JobOfferId = id;
        }

        public long JobOfferId { get; set; }
        public string Text { get; set; }

        public JobOfferStatus Status { get; set; }
        public List<JobOfferStatus> Statuses { get; set; }
    }
}