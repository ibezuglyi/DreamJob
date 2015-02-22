namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class ProfileLoginViewModel
    {
        public ProfileLoginViewModel(ProfileLoginDto dto)
        {
            this.Email = dto.Email;
        }

        public ProfileLoginViewModel()
            : this(new ProfileLoginDto())
        {
        }

        public string Password { get; set; }
        public string Email { get; set; }
    }
}