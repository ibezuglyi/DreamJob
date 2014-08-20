using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    public interface IAuthentication
    {
        DjOperationResult<bool> AuthenticateUser(LoginUserDto data);
        DjOperationResult<bool> LogoffUser();
    }
}