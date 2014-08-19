namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;

    public class ResetSessionWhenOutOfSyncWithForms : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = HttpContext.Current.Session;
            if (session[DjSessionKeys.CurrentUser] == null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    session.Clear();
                    FormsAuthentication.SignOut();
                    filterContext.Result =
                        new RedirectToRouteResult(
                            new RouteValueDictionary(new { controller = "Login", action = "Index" }));
                    filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);

                }
            }
        }
    }
}