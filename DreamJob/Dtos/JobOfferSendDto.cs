namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class JobOfferSendDto
    {
        public JobOfferSendDto()
            : this(0)
        { }

        public JobOfferSendDto(long developerId)
        {
            this.DeveloperId = developerId;
            this.JobOfferText = string.Empty;
            this.Position = string.Empty;
            this.Salary = 0;
            this.CompanyName = string.Empty;
            this.Requirements = string.Empty;
            this.OfferMatchesProfile = false;
            this.ProfileWasReadBeforeSending = false;
        }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_DeveloperId_Required")]
        public long DeveloperId { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_JobOfferText_Required")]
        [StringLength(int.MaxValue,
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_JobOfferText_Length",
            MinimumLength = 3)]
        [AllowHtml]
        public string JobOfferText { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations), 
            ErrorMessageResourceName = "JobOfferSend_Dto_Position_Required")]
        [StringLength(int.MaxValue,
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_Position_Length",
            MinimumLength = 3)]
        [AllowHtml]
        public string Position { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_Salary_Required")]
        public decimal Salary { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_CompanyName_Required")]
        [StringLength(int.MaxValue,
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_CompanyName_Length",
            MinimumLength = 3)]
        [AllowHtml]
        public string CompanyName { get; set; }

        [Required(
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_Requirements_Required")]
        [StringLength(int.MaxValue,
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_Requirements_Length",
            MinimumLength = 3)]
        [AllowHtml]
        public string Requirements { get; set; }

        [RegularExpression("True",
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_OfferMatchesProfile")]
        public bool OfferMatchesProfile { get; set; }

        [RegularExpression("True",
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "JobOfferSend_Dto_ProfileWasReadBeforeSending")]
        public bool ProfileWasReadBeforeSending { get; set; }
    }
}