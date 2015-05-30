namespace DreamJob.ViewModels
{
    using Dtos;
    public class JobOfferSendViewModel
    {
        public JobOfferSendDto JobOfferSendDto { get; set; }
        public string LookingFor { get; set; }
        public decimal Salary { get; set; }

        public JobOfferSendViewModel(JobOfferSendDto jobOfferSendDto, string lookingFor, decimal salary)
        {
            JobOfferSendDto = jobOfferSendDto;
            LookingFor = lookingFor;
            Salary = salary;
        }

        public JobOfferSendViewModel(long developerId, string lookingFor, decimal salary)
            : this(new JobOfferSendDto(developerId, salary), lookingFor, salary)
        {
        }


    }
}