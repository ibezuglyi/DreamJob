namespace DreamJob.ViewModels
{
    using Dtos;

    public class JobOfferRejectViewModel
    {
        public JobOfferRejectDto JobOfferRejectDto { get; set; }
        public string Position { get; set; }
        public string CompanyName { get; set; }
        public decimal Salary { get; set; }

        public JobOfferRejectViewModel(JobOfferRejectDto jobOfferRejectDto, string position, string companyName, decimal salary)
        {
            JobOfferRejectDto = jobOfferRejectDto;
            Position = position;
            CompanyName = companyName;
            Salary = salary;
        }

        public JobOfferRejectViewModel(long jobOfferId, string position,string companyName , decimal salary)
            : this(new JobOfferRejectDto(jobOfferId), position, companyName, salary)
        {
            
        }
    }
}