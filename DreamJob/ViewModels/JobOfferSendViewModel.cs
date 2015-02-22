namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class JobOfferSendViewModel
    {
        public JobOfferSendViewModel():this(new JobOfferSendDto())
        {}

        public JobOfferSendViewModel(JobOfferSendDto dto)
        {
            this.DeveloperId = dto.DeveloperId;
            this.JobOfferText = dto.JobOfferText;
            this.Position = dto.Position;
            this.Salary = dto.Salary;
            this.CompanyName = dto.CompanyName;
            this.Requirements = dto.Requirements;
        }

        public JobOfferSendViewModel(long developerId):this(new JobOfferSendDto(developerId))
        {}

        public long DeveloperId { get; set; }
        public string JobOfferText { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string CompanyName { get; set; }
        public string Requirements { get; set; }
        public bool OfferMatchesProfile { get; set; }
        public bool ProfileWasReadBeforeSending { get; set; }
    }
}