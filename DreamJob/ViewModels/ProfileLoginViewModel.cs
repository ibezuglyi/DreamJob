namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class ProfileLoginViewModel
    {
        public ProfileLoginViewModel(ProfileLoginDto dto)
        {
            this.Email = dto.Email;
            this.RememberMe = dto.RememberMe;
        }

        public ProfileLoginViewModel()
            : this(new ProfileLoginDto())
        {
        }

        public bool RememberMe { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}