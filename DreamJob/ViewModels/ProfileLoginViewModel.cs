
namespace DreamJob.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Dtos;

    public class ProfileLoginViewModel
    {
        public ProfileLoginViewModel(ProfileLoginDto dto)
        {
            this.Email = dto.Email;
            this.RememberMe = dto.RememberMe;
            this.ReturnUrl = dto.ReturnUrl;
        }


        public ProfileLoginViewModel(string returnUrl="")
            : this(new ProfileLoginDto(returnUrl))
        {
        }

        public string ReturnUrl { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfileLoginViewModel_RememberMe")]
        public bool RememberMe { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfileLoginViewModel_Password")]
        public string Password { get; set; }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfileLoginViewModel_Email")]
        public string Email { get; set; }
    }
}