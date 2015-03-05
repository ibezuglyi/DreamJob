namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ProfilePrivateRecruiterDto
    {
        [Required]
        [AllowHtml]
        public string FirstName { get; set; }
        [Required]
        [AllowHtml]
        public string LastName { get; set; }
        [Required]
        [AllowHtml]
        public string Email { get; set; }
        [Required]
        [AllowHtml]
        public string Employer { get; set; }

        public bool IsActive { get; set; }
    }
}