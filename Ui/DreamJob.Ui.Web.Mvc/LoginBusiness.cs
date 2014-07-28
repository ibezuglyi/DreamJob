namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public class LoginBusiness : ILoginBusiness
    {
        private readonly IPasswordHasher passwordHasher;
        private readonly ILoginService loginService;
        private readonly IUserService userService;

        public LoginBusiness(IPasswordHasher passwordHasher, ILoginService loginService, IUserService userService)
        {
            this.passwordHasher = passwordHasher;
            this.loginService = loginService;
            this.userService = userService;
        }

        public DjOperationResult<LoginDTO> GetLoginViewModel()
        {
            var model = new LoginDTO();
            var result = new DjOperationResult<LoginDTO>(model);
            return result;
        }

        public DjOperationResult<bool> LoginUser(LoginDTO model)
        {
            var passwordHash = this.passwordHasher.GetHash(model.Password);
            var userLoginResult = this.userService.GetUserLoginDto(model.Login, passwordHash);
            if (userLoginResult.IsSuccess == false)
            {
                return new DjOperationResult<bool>(false, userLoginResult.Errors);
            }

            var loginUserResult = this.loginService.LoginUser(userLoginResult.Data);
            return loginUserResult;
        }
    }
}