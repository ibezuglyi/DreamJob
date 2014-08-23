namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface ISession
    {
        DjOperationResult<bool> SetCurrentUser(LoginUserDto data);
        DjOperationResult<bool> ClearUserData();

        DjOperationResult<LoginUserDto> GetCurrentUser();
    }
}