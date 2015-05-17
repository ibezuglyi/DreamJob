using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class ProfileRegisterViewModel
    {
        public ProfileRegisterViewModel()
            : this(string.Empty, ApplicationUserRole.Anonymous)
        { }

        public ProfileRegisterViewModel(ProfileRegisterDto dto)
            : this(dto.Email, dto.Role)
        { }

        private ProfileRegisterViewModel(string email, ApplicationUserRole role)
        {
            this.Email = email;
            this.Password = string.Empty;
            this.ConfirmPassword = string.Empty;
            this.Role = role;
        }

        [Display(
            ResourceType = typeof(Resources.Translations),
            Name = "ProfileRegisterViewModel_Email")]
        public string Email { get; set; }

        [Display(
           ResourceType = typeof(Resources.Translations),
           Name = "ProfileRegisterViewModel_Password")]
        public string Password { get; set; }

        [Display(
           ResourceType = typeof(Resources.Translations),
           Name = "ProfileRegisterViewModel_ConfirmPassword")]
        public string ConfirmPassword { get; set; }

        public ApplicationUserRole Role { get; set; }
    }
}