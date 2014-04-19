namespace DreamJob.Services
{
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Services.Interfaces;
    using DreamJob.Services.Interfaces.Model;

    public class LoginService : ILoginService
    {
        private readonly IUserRepository userRepository;
        private readonly ISession session;

        public LoginService(IUserRepository userRepository, ISession session)
        {
            this.userRepository = userRepository;
            this.session = session;
        }

        public void Login(UserLoginData recruiterLoginData)
        {
            var user = this.userRepository.GetUserPublicDataByLoginAndHash(
                recruiterLoginData.Login,
                recruiterLoginData.HashedPassword);

            this.session.SetLoggedUser(user);
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public bool UserExists(UserLoginData userLoginData)
        {
            var result = this.userRepository.UserExists(userLoginData.Login, userLoginData.HashedPassword);
            return result;
        }
    }
}