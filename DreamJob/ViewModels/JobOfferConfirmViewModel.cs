using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class JobOfferConfirmViewModel
    {
        public long JobOfferId { get; set; }
        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferConfirmViewModel_Text")]
        public string Text { get; set; }

        public JobOfferConfirmViewModel(JobOfferConfirmDto dto)
            : this(dto.JobOfferId, dto.Text)
        {}

        public JobOfferConfirmViewModel(long jobOfferId)
            : this(jobOfferId, string.Empty)
        {}

        private JobOfferConfirmViewModel(long jobOfferId, string text)
        {
            this.JobOfferId = jobOfferId;
            this.Text = text;
        }
    }
}