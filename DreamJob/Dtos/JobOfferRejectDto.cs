using System.ComponentModel.DataAnnotations;

namespace DreamJob.Dtos
{
    using System.Web.Mvc;

    public class JobOfferRejectDto
    {
        public JobOfferRejectDto(long jobOfferId)
        {
            JobOfferId = jobOfferId;
        }

        public long JobOfferId { get; set; }

        [AllowHtml]
        [Display(ResourceType = typeof(Resources.Translations), Name = "JobOfferRejectViewModel_Text")]
        public string Text { get; set; }
    }
}