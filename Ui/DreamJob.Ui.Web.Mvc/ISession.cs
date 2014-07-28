namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    internal interface ISession
    {
        DjOperationResult<bool> SetCurrentUser(LoginUserDto data);
    }
}