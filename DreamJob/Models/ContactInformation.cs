namespace DreamJob.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ContactInformation : DJDbBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }

        [Required]
        public long JobOfferStatusChangeId { get; set; }
        [Required]
        public virtual JobOfferStatusChange JobOfferStatusChange { get; set; }
    }
}