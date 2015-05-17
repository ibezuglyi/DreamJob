using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class JobOfferAcceptViewModel
    {
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
            this.ContactInformation = new ContactInformationViewModel();
        }

        public long JobOfferId { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferAcceptViewModel_Text")]
        public string Text { get; set; }
        public ContactInformationViewModel ContactInformation { get; set; }

        
    }
}