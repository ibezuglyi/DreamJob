namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public interface IUserService
    {
        DjOperationResult<LoginUserDto> GetUserLoginDto(string login, string passwordHash);

        DjOperationResult<UserProfileDto> GetFullUserProfile(long userId);
    }
}