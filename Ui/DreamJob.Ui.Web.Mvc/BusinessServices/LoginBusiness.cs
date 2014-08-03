﻿using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Controllers;
using DreamJob.Ui.Web.Mvc.Helpers;
using DreamJob.Ui.Web.Mvc.Models.Dto;
using DreamJob.Ui.Web.Mvc.Services;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
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