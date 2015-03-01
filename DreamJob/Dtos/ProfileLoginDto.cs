namespace DreamJob.Dtos
{
    using System.ComponentModel.DataAnnotations;

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
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}