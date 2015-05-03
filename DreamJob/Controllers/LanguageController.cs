using System.Web;
using System.Web.Mvc;

namespace DreamJob.Controllers
{
    public class LanguageController : DjBaseController
    {
        public ActionResult ChangeLanguage(string newlanguage, string returnUrl)
        {
            var httpCookie = new HttpCookie(Constants.Strings.Cookie, newlanguage);
            this.Response.Cookies.Add(httpCookie);
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                return this.RedirectToAction("Index", "Home");
            }
            return this.Redirect(returnUrl);
        }
    }
}