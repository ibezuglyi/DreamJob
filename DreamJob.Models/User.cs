namespace DreamJob.Models
{
    public abstract class User
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string EmailAddress { get; set; }
    }
}