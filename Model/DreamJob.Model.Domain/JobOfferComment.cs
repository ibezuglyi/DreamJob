using System;

namespace DreamJob.Model.Domain
{
    public class JobOfferComment : BaseEntity
    {
        public JobOfferComment()
        {
            
        }
        public JobOfferComment(long authorId, DateTime added, DateTime edited, long offerId, JobOfferCommentStatus jobOfferCommentStatus, string text)
        {
            this.AuthorId = authorId;
            this.Add = added;
            this.Edit = edited;
            this.JobOfferId = offerId;
            this.Status = jobOfferCommentStatus;
            this.Text = text;
        }
        public JobOffer JobOffer { get; set; }
        public long JobOfferId { get; set; }
        public User Author { get; set; }
        public long AuthorId { get; set; }
        public string Text { get; set; }
        public JobOfferCommentStatus Status { get; set; }
    }
}