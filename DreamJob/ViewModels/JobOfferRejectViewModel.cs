namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class JobOfferRejectViewModel
    {
        public long JobOfferId { get; set; }
        public string Text { get; set; }

        public JobOfferRejectViewModel(JobOfferRejectDto dto)
            : this(dto.JobOfferId, dto.Text)
        { }

        public JobOfferRejectViewModel(long jobOfferId, string text)
        {
            this.JobOfferId = jobOfferId;
            this.Text = text;
        }

        public JobOfferRejectViewModel(long jobOfferId)
            : this(jobOfferId, string.Empty)
        { }
    }
}