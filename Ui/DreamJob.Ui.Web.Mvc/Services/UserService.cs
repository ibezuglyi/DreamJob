namespace DreamJob.Ui.Web.Mvc.Services
{
    using System;

    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Repositories;

    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public DjOperationResult<LoginUserDto> GetUserLoginDto(string login, string passwordHash)
        {
            var findUserResult = this.userRepository.FindUserByLoginAndPasswordHash(login, passwordHash);
            if (findUserResult.IsSuccess == false)
            {
                return new DjOperationResult<LoginUserDto>(false, findUserResult.Errors);
            }
            if (findUserResult.Data == null)
            {
                return new DjOperationResult<LoginUserDto>(false, new[] { "Didn't found any user with given login and password" });
            }

            var userDto = Mapper.Map<User, LoginUserDto>(findUserResult.Data);
            var result = new DjOperationResult<LoginUserDto>(userDto);
            return result;
        }

        public DjOperationResult<DateTime> GetAccountCreation(string login)
        {
            var findUserResult = this.userRepository.FindUserByLogin(login);
            if (findUserResult.IsSuccess == false)
            {
                return new DjOperationResult<DateTime>(false, findUserResult.Errors);
            }

            if (findUserResult.Data == null)
            {
                return new DjOperationResult<DateTime>(false, new[] { "No user was found using this login" });
            }

            return new DjOperationResult<DateTime>(findUserResult.Data.Add);
        }
    }
}