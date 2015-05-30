namespace DreamJob.ViewModels
{
    using Dtos;

    public class JobOfferCancelViewModel
    {
        public JobOfferCancelDto JobOfferCancelDto { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }


        public JobOfferCancelViewModel(JobOfferCancelDto jobOfferCancelDto, string companyName, string position, decimal salary)
        {
            JobOfferCancelDto = jobOfferCancelDto;
            CompanyName = companyName;
            Position = position;
            Salary = salary;
        }

        public JobOfferCancelViewModel(long jobOfferId, string companyName, string position, decimal salary)
            : this(new JobOfferCancelDto(jobOfferId), companyName, position, salary)
        {
        }


    }
}