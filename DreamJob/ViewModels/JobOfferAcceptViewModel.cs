namespace DreamJob.ViewModels
{
    using Dtos;

    public class JobOfferAcceptViewModel
    {
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public JobOfferAcceptDto JobOfferAcceptDto { get; set; }

        private JobOfferAcceptViewModel(string companyName, string position, decimal salary)
        {
            CompanyName = companyName;
            Position = position;
            Salary = salary;
        }

        public JobOfferAcceptViewModel(JobOfferAcceptDto dto, string companyName, string position, decimal salary)
            : this(companyName, position, salary)
        {
            JobOfferAcceptDto = dto;
        }

        public JobOfferAcceptViewModel(long jobOfferId, string companyName, string position, decimal salary)
            : this(companyName, position, salary)
        {
            JobOfferAcceptDto = new JobOfferAcceptDto(jobOfferId);
        }

        
    }
}