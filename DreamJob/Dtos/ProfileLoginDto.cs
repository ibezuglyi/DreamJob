namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ProfileLoginDto
    {
        public ProfileLoginDto(string returnUrl)
        {
            this.ReturnUrl = returnUrl;
        }

        public ProfileLoginDto()
            : this(string.Empty)
        { }

        [AllowHtml]
        [Required(ErrorMessageResourceType = typeof(Resources.Translations), ErrorMessageResourceName = "ProfileLoginDto_EmailRequired")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Translations), ErrorMessageResourceName = "ProfileLoginDto_PasswordRequired")]
        [AllowHtml]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}