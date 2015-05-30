namespace DreamJob.Dtos
{
    public class JobOfferAcceptDto
    {
        
        public long JobOfferId { get; set; }
        public ContactInformationDto ContactInformation { get; set; }

        public JobOfferAcceptDto()
        {
            ContactInformation = new ContactInformationDto();
        }

        public JobOfferAcceptDto(long jobOfferId):this()
        {
            JobOfferId = jobOfferId;
        }
    }
}