namespace DreamJob.Model.Domain
{
    public class Offer
    {
        public long Id { get; set; }

        public User From { get; set; }

        public User To { get; set; }
    }
}