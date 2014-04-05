namespace DreamJob.Services
{
    using DreamJob.Interfaces;
    using DreamJob.Services.Interfaces;

    public class LoginService : ILoginService
    {
        public LoginService(IUserRepository userRepository, ISession session)
        {
            throw new System.NotImplementedException();
        }

        public void Login(object recruiterLoginData)
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}