namespace DreamJob.Domain.Models
{
    public abstract class User : BaseEntity
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddress { get; set; }
    }
}