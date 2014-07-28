namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    class LoginService : ILoginService
    {
        private readonly IAuthentication authentication;

        private readonly ISession session;

        public LoginService(IAuthentication authentication, ISession session)
        {
            this.authentication = authentication;
            this.session = session;
        }

        public DjOperationResult<bool> LoginUser(LoginUserDto data)
        {
            var authenticationResult = this.authentication.AuthenticateUser(data);
            if (authenticationResult.IsSuccess == false)
            {
                return authenticationResult;
            }

            var sessionResult = this.session.SetCurrentUser(data);
            return sessionResult;
        }
    }
}