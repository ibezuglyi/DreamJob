namespace DreamJob.Models
{
    using DreamJob.ViewModels;
    public class UserAccount : DJDbBase
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public ApplicationUserRole Role { get; set; }

        public virtual Developer Developer { get; set; }
        public virtual Recruiter Recruiter { get; set; }
    }
}