namespace DreamJob.Ui.Web.Mvc
{
    using System.Web;

    using DreamJob.Common.Enum;

    class Session : ISession
    {
        public DjOperationResult<bool> SetCurrentUser(LoginUserDto data)
        {
            HttpContext.Current.Session[DjSessionKeys.CurrentUser] = data;
            HttpContext.Current.Session[DjSessionKeys.DisplayName] = data.DisplayName;
            return DjOperationResult<bool>.Success();
        }
    }

    public static class DjSessionKeys
    {
        public static string CurrentUser { get { return "Dj.SessionKey.CurrentUser"; } }
        public static string DisplayName { get { return "Dj.SessionKey.DisplayName"; } }
    }
}