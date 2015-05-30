using System.ComponentModel.DataAnnotations;

namespace DreamJob.Dtos
{
    using System.Web.Mvc;

    public class JobOfferCancelDto
    {
        
        public long JobOfferId { get; set; }

        [AllowHtml]
        [Display(ResourceType = typeof(Resources.Translations), Name = "JobOfferCancelViewModel_Text")]
        public string Text { get; set; }

        public JobOfferCancelDto()
        {
        }

        public JobOfferCancelDto(long jobOfferId)
        {
            JobOfferId = jobOfferId;
        }
    }
}