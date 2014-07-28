namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    using Microsoft.Ajax.Utilities;

    public interface ILoginService
    {
        DjOperationResult<bool> LoginUser(LoginUserDto data);
    }
}