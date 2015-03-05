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
        {}

        [Required]
        [AllowHtml]
        public string Email { get; set; }

        [Required]
        [AllowHtml]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}