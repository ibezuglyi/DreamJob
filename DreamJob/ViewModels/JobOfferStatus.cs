using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    public enum JobOfferStatus
    {
        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferStatus_None")]
        None,

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferStatus_New")]
        New,

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferStatus_Read")]
        Read,

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferStatus_Rejected")]
        Rejected,

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferStatus_Canceled")]
        Canceled,

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferStatus_Accepted")]
        Accepted,

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferStatus_Confirmed")]
        Confirmed
    }
}