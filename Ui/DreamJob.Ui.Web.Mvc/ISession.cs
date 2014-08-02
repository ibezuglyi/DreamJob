using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    public interface ISession
    {
        DjOperationResult<bool> SetCurrentUser(LoginUserDto data);
        DjOperationResult<bool> ClearUserData();

        DjOperationResult<LoginUserDto> GetCurrentUser();
    }
}