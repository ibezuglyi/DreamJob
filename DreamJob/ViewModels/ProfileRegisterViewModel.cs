namespace DreamJob.ViewModels
{
    using DreamJob.Dtos;

    public class ProfileRegisterViewModel
    {
        public ProfileRegisterViewModel()
            : this(string.Empty, string.Empty, ApplicationUserRole.None)
        { }

        public ProfileRegisterViewModel(ProfileRegisterDto dto)
            : this(dto.DisplayName, dto.Email, dto.Role)
        { }

        private ProfileRegisterViewModel(string displayName, string email, ApplicationUserRole role)
        {
            this.DisplayName = displayName;
            this.Email = email;
            this.Password = string.Empty;
            this.ConfirmPassword = string.Empty;
            this.Role = role;
        }

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public ApplicationUserRole Role { get; set; }
    }
}