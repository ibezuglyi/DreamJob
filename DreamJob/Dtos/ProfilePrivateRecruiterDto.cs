namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class ProfilePrivateRecruiterDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Employer { get; set; }

        public bool IsActive { get; set; }
    }
}