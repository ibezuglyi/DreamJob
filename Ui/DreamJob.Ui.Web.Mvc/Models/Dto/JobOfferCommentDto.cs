using DreamJob.Common.Enum;

namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    using System;

    using DreamJob.Model.Domain;

    public class JobOfferCommentDto
    {
        public long Id { get; set; }
        public string Add { get; set; }
        public long JobOfferId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public JobOfferCommentStatus Status { get; set; }
        public OfferStatus NewOfferStatus { get; set; }
    }
}