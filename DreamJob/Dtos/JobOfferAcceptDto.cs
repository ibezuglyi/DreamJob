namespace DreamJob.Dtos
{
    using System.Web.Mvc;

    public class JobOfferAcceptDto
    {
        public long JobOfferId { get; set; }
        
        [AllowHtml]
        public string Text { get; set; }

        public ContactInformationDto ContactInformation { get; set; }
    }
}