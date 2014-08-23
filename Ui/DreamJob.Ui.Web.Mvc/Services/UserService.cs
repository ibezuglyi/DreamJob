namespace DreamJob.Ui.Web.Mvc.Services
{
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

        public DjOperationResult<UserProfileDto> GetFullUserProfile(long userId)
        {
            var getUserResult = this.userRepository.GetUser(userId);
            if (getUserResult.IsSuccess == false)
            {
                return new DjOperationResult<UserProfileDto>(false, getUserResult.Errors);
            }

            var userProfileDto = Mapper.Map<User, UserProfileDto>(getUserResult.Data);
            return new DjOperationResult<UserProfileDto>(userProfileDto);
        }
    }
}