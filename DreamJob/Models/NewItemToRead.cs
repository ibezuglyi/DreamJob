namespace DreamJob.Models
{
    public class NewMessageToRead : DJDbBase
    {
        public NewMessageToRead()
            : this(-1, -1, ApplicationMessageType.None)
        { }

        public NewMessageToRead(long userAccountId, long jobOfferId, ApplicationMessageType messageType)
        {
            this.MessageType = messageType;
            this.UserAccountId = userAccountId;
            this.JobOfferId = jobOfferId;
        }

        public ApplicationMessageType MessageType { get; set; }

        public long UserAccountId { get; set; }
        public virtual UserAccount UserAccount { get; set; }

        public long JobOfferId { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}