namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

    using DreamJob.ViewModels;

    public class ProfileRegisterDto
    {
        [Required]
        [MinLength(3)]
        public string DisplayName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public ApplicationUserRole Role { get; set; }
    }
}