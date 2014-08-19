namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;

    using DreamJob.Model.Domain;

    public class JobOfferCommentDto
    {
        public long Id { get; set; }
        public DateTime Add { get; set; }
        public long JobOfferId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public JobOfferCommentStatus Status { get; set; }
    }
}