namespace DreamJob.Controllers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using Constants;

    public abstract class DjBaseController : Controller
    {
        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            string cultureName;

            HttpCookie cultureCookie = this.Request.Cookies[Strings.Cookie];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else
            {
                cultureName = this.GetCultureFromBrowser();
            }

            if (string.IsNullOrWhiteSpace(cultureName))
            {
                cultureName = Strings.DefaultCulture;
            }

            SetNewCulture(cultureName);

            return base.BeginExecuteCore(callback, state);
        }

        private static void SetNewCulture(string cultureName)
        {
            var newCulture = new CultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
        }

        private string GetCultureFromBrowser()
        {
            var cultureFromBrowser = this.Request.UserLanguages != null && this.Request.UserLanguages.Any()
                ? this.Request.UserLanguages.First()
                : null;
            return cultureFromBrowser;
        }
    }
}