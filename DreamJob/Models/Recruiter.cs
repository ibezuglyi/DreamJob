namespace DreamJob.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Recruiter : DJDbBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Employer { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public long UserAccountId { get; set; }

        [Required]
        public virtual UserAccount Account { get; set; }
    }
}