namespace DreamJob.Infrastructure
{
    using System.Web;
    using System.Web.Security;

    using DreamJob.ViewModels;

    public class FormAuthentication : IAuthentication
    {
        public void LoginUser(ApplicationUser applicationUser)
        {
            FormsAuthentication.SetAuthCookie(applicationUser.Id.ToString(), false);
            HttpContext.Current.Session["ApplicationUser"] = applicationUser;
        }

        public void LogoutUser()
        {
            FormsAuthentication.SignOut();
            HttpContext.Current.Session["ApplicationUser"] = null;
        }

        public long GetCurrentLoggedUserId()
        {
            var applicationUser = HttpContext.Current.Session["ApplicationUser"] as ApplicationUser;
            var id = applicationUser.Id;
            return id;
        }

        public ApplicationUserRole GetCurrentLoggedUserRole()
        {
            var result = ApplicationUserRole.None;
            var applicationUser = HttpContext.Current.Session["ApplicationUser"] as ApplicationUser;
            if (applicationUser != null)
            {
                result = applicationUser.Role;
            }

            return result;
        }
    }
}