namespace DreamJob.Services.Interfaces.Model
{
    public class UserLoginData
    {
        public string Login { get; set; }
        public string HashedPassword { get; set; }
        public bool RememberMe { get; set; }
    }
}