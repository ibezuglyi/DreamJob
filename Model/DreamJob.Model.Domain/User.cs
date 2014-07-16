namespace DreamJob.Model.Domain
{
    public class User
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string DisplayName { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public UserAccountType AccountType { get; set; }
    }
}