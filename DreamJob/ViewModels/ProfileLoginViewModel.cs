namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

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
        public bool RememberMe { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}