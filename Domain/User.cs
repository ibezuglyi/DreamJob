namespace DreamJob.Domain.Models
{
    public abstract class User : BaseEntity
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddress { get; set; }
        public UserAccountType AccountType { get; set; }
    }

    public enum UserAccountType
    {
        None,
        Candidate,
        Recruiter
    }
}