
namespace DreamJob.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Dtos;

    public class JobOfferSendViewModel
    {
        public JobOfferSendViewModel() : this(new JobOfferSendDto())
        {
        }

        public JobOfferSendViewModel(JobOfferSendDto dto)
        {
            this.DeveloperId = dto.DeveloperId;
            this.JobOfferText = dto.JobOfferText;
            this.Position = dto.Position;
            this.Salary = dto.Salary;
            this.CompanyName = dto.CompanyName;
            this.Requirements = dto.Requirements;
        }

        public JobOfferSendViewModel(long developerId) : this(new JobOfferSendDto(developerId))
        {
        }

        public long DeveloperId { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "JobOfferSendViewModel_JobOfferText")]
        public string JobOfferText { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "JobOfferSendViewModel_Position")]
        public string Position { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "JobOfferSendViewModel_Salary")]
        public decimal Salary { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "JobOfferSendViewModel_CompanyName")]
        public string CompanyName { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "JobOfferSendViewModel_Requirements")]
        public string Requirements { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "JobOfferSendViewModel_OfferMatchesProfile")]
        public bool OfferMatchesProfile { get; set; }

        [Display(
            ResourceType = typeof (Resources.Translations),
            Name = "JobOfferSendViewModel_ProfileWasReadBeforeSending")]
        public bool ProfileWasReadBeforeSending { get; set; }
    }
}