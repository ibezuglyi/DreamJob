namespace DreamJob.Dtos
{
    using System.Web.Mvc;

    public class JobOfferCancelDto
    {
        public long JobOfferId { get; set; }
        [AllowHtml]

        public string Text { get; set; }
    }
}