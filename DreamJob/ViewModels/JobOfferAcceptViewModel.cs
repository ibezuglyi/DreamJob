namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class JobOfferAcceptViewModel
    {
        public long JobOfferId { get; set; }
        public string Text { get; set; }

        public JobOfferAcceptViewModel(JobOfferAcceptDto dto)
            : this(dto.JobOfferId, dto.Text)
        { }

        public JobOfferAcceptViewModel(long jobOfferId)
            : this(jobOfferId, string.Empty)
        { }

        public JobOfferAcceptViewModel(long jobOfferId, string text)
        {
            this.JobOfferId = jobOfferId;
            this.Text = text;
        }
    }
}