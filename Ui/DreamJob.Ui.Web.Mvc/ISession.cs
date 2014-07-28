namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    public interface ISession
    {
        DjOperationResult<bool> SetCurrentUser(LoginUserDto data);
    }
}