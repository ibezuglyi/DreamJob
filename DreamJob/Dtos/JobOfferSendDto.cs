namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

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

        [Required]
        public long DeveloperId { get; set; }

        [Required]
        [MinLength(10)]
        public string JobOfferText { get; set; }

        [Required]
        [MinLength(3)]
        public string Position { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        [MinLength(3)]
        public string CompanyName { get; set; }

        [Required]
        [MinLength(3)]
        public string Requirements { get; set; }

        [Required]
        [RegularExpression("True")]
        public bool OfferMatchesProfile { get; set; }

        [Required]
        [RegularExpression("True")]
        public bool ProfileWasReadBeforeSending { get; set; }
    }
}