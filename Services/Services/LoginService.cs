namespace DreamJob.Services
{
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Services.Interfaces;
    using DreamJob.Services.Interfaces.Model;

    public class LoginService : ILoginService
    {
        private readonly IUserRepository userRepository;

        public LoginService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Login(UserLoginData recruiterLoginData)
        {
            var user = this.userRepository.FindUserByLoginAndHash(
                recruiterLoginData.Login,
                recruiterLoginData.HashedPassword);

        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }
    }
}