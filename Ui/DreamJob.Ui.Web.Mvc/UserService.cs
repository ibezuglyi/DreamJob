namespace DreamJob.Ui.Web.Mvc
{
    using AutoMapper;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    class UserService : IUserService
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
    }
}