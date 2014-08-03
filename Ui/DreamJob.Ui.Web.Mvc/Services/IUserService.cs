using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Controllers;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Services
{
    public interface IUserService
    {
        DjOperationResult<LoginUserDto> GetUserLoginDto(string login, string passwordHash);

        DjOperationResult<UserProfileDto> GetFullUserProfile(long userId);
    }
}