namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class ContactInformationDto
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Note { get; set; }
    }
}