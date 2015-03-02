namespace DreamJob.ViewModels
{
    using System;

    public class JobOfferHeadlineViewModel
    {
        public long Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string CompanyName { get; set; }
        public string DeveloperDisplayName { get; set; }
        public JobOfferStatus Status { get; set; }

        public long DeveloperId { get; set; }

        public long MessagesCount { get; set; }
    }
}