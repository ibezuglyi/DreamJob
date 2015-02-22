namespace DreamJob.ViewModels
{
    public class ProfilePublicRecruiterViewModel
    {
        public ProfilePublicRecruiterViewModel()
        {
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Employer = string.Empty;
            this.PhoneNumber = string.Empty;
            this.Email = string.Empty;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Employer { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}