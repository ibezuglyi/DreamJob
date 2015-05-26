using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using Dtos;

    public class JobOfferCancelViewModel
    {
        public long JobOfferId { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferCancelViewModel_Text")]
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