namespace DreamJob.Ui.Web.Mvc
{
    using System.Web.Security;

    using DreamJob.Common.Enum;

    class FormAuthentication : IAuthentication
    {
        public DjOperationResult<bool> AuthenticateUser(LoginUserDto data)
        {
            FormsAuthentication.SetAuthCookie(data.DisplayName, data.PersistentLogin);
            return DjOperationResult<bool>.Success();
        }
    }
}