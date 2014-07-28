namespace DreamJob.Ui.Web.Mvc
{
    using System.Web;

    using DreamJob.Common.Enum;

    class Session : ISession
    {
        public DjOperationResult<bool> SetCurrentUser(LoginUserDto data)
        {
            HttpContext.Current.Session[DjSessionKeys.CurrentUser] = data;
            return DjOperationResult<bool>.Success();
        }
    }

    internal class DjSessionKeys
    {
        public static string CurrentUser { get { return "Dj.SessionKey.CurrentUser"; } }
    }
}