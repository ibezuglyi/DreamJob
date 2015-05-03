namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using ViewModels;

    public class ProfileRegisterDto
    {
        [Required(
          ErrorMessageResourceType = typeof(Resources.Translations),
          ErrorMessageResourceName = "ProfileRegisterDto_Email_Required")]
        [EmailAddress]
        [AllowHtml]
        public string Email { get; set; }

        [Required(
          ErrorMessageResourceType = typeof(Resources.Translations),
          ErrorMessageResourceName = "ProfileRegisterDto_Password_Required")]
        [StringLength(int.MaxValue,
            ErrorMessageResourceType = typeof(Resources.Translations),
            ErrorMessageResourceName = "ProfileRegisterDto_Password_Length",
            MinimumLength = 4)]
        [AllowHtml]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [AllowHtml]
        public string ConfirmPassword { get; set; }

        public ApplicationUserRole Role { get; set; }
    }
}