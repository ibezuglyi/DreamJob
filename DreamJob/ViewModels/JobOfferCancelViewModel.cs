namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class JobOfferCancelViewModel
    {
        public long JobOfferId { get; set; }
        public string Text { get; set; }

        public JobOfferCancelViewModel(JobOfferCancelDto dto)
            : this(dto.JobOfferId, dto.Text)
        {
        }

        public JobOfferCancelViewModel(long jobOfferId)
            : this(jobOfferId, string.Empty)
        {
        }

        public JobOfferCancelViewModel(long jobOfferId, string text)
        {
            this.JobOfferId = jobOfferId;
            this.Text = text;
        }
    }
}