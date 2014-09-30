using System.ComponentModel.DataAnnotations;

namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    public class UserRegistrationDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        [Display(Name = "Display name")]
        public string DisplayName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}