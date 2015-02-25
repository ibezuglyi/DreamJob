namespace DreamJob.Dtos
{
    public class JobOfferAcceptDto
    {
        public long JobOfferId { get; set; }
        public string Text { get; set; }

        public ContactInformationDto ContactInformation { get; set; }
    }
}