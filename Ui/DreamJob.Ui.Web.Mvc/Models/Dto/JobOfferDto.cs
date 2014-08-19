namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    using System;

    using DreamJob.Common.Enum;

    public class JobOfferDto
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public DateTime Add { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Description { get; set; }
        public OfferStatus OfferStatus { get; set; }
    }
}