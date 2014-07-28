namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    internal interface IAuthentication
    {
        DjOperationResult<bool> AuthenticateUser(LoginUserDto data);
        DjOperationResult<bool> LogoffUser();
    }
}