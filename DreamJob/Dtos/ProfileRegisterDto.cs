namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using DreamJob.ViewModels;

    public class ProfileRegisterDto
    {
        [Required]
        [EmailAddress]
        [AllowHtml]
        public string Email { get; set; }

        [Required]
        [MinLength(4)]
        [AllowHtml]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [AllowHtml]
        public string ConfirmPassword { get; set; }

        public ApplicationUserRole Role { get; set; }
    }
}