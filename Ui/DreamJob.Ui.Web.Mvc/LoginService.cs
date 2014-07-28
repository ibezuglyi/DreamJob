namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    class LoginService : ILoginService
    {
        private readonly IAuthentication authentication;

        private readonly ISession session;

        private readonly IUserRepository userRepository;

        public LoginService(IAuthentication authentication, ISession session, IUserRepository userRepository)
        {
            this.authentication = authentication;
            this.session = session;
            this.userRepository = userRepository;
        }

        public DjOperationResult<bool> LoginUser(LoginUserDto data)
        {
            var authenticationResult = this.authentication.AuthenticateUser(data);
            if (authenticationResult.IsSuccess == false)
            {
                return authenticationResult;
            }

            this.userRepository.UpdateLastLoginData(data.Id);

            var sessionResult = this.session.SetCurrentUser(data);
            return sessionResult;
        }
    }
}