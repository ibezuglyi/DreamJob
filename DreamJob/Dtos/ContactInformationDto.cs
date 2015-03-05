namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ContactInformationDto
    {
        [Required]
        [AllowHtml]
        public string FirstName { get; set; }
        
        [AllowHtml]
        public string LastName { get; set; }

        [Required]
        [AllowHtml]
        public string Email { get; set; }

        [Required]
        [AllowHtml]
        public string Phone { get; set; }
        
        [AllowHtml]
        public string Note { get; set; }
    }
}