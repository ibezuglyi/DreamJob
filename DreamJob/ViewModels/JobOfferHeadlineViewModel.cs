using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using System;

    public class JobOfferHeadlineViewModel
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferHeadlineViewModel_Position")]
        public string Position { get; set; }
        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferHeadlineViewModel_Salary")]
        public decimal Salary { get; set; }
        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferHeadlineViewModel_CompanyName")]
        public string CompanyName { get; set; }
        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "JobOfferHeadlineViewModel_DeveloperDisplayName")]
        public string DeveloperDisplayName { get; set; }
        public JobOfferStatus Status { get; set; }

        public long DeveloperId { get; set; }

        public long MessagesCount { get; set; }
        public string MessageCountToShow
        {
            get
            {
                return this.MessagesCount > 0 ? string.Format("({0})", this.MessagesCount.ToString()) : string.Empty;
            }
        }
        public bool IsBoldedLine
        {
            get { return this.MessagesCount > 0; }
        }
    }
}