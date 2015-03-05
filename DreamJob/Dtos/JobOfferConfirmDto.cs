namespace DreamJob.Dtos
{
    using System.Web.Mvc;

    public class JobOfferConfirmDto
    {
        public long JobOfferId { get; set; }

        [AllowHtml]
        public string Text { get; set; }
    }
}