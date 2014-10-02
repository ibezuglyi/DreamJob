namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Helpers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Services;

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

        public DjOperationResult<LoginDto> GetLoginViewModel()
        {
            var model = new LoginDto();
            var result = new DjOperationResult<LoginDto>(model);
            return result;
        }

        public DjOperationResult<bool> LoginUser(LoginDto model)
        {
            var accountCreationResult = this.userService.GetAccountCreation(model.Login);

            if (accountCreationResult.IsSuccess == false)
            {
                return new DjOperationResult<bool>(false, new[] { "No user was found using this login or password." });
            }
            var userSalt = accountCreationResult.Data.ToFileTime().ToString();

            var passwordHash = this.passwordHasher.GetHash(model.Password, userSalt);
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