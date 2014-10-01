using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DreamJob.Common.Enum;

namespace DreamJob.Ui.Web.Mvc.Helpers
{
    public static class ControllerHelper
    {
        public static JsonResult DjJson<T>(this Controller controller, DjOperationResult<T> opreationResult)
        {
            if (opreationResult.IsSuccess)
            {
                return new JsonResult() { Data = opreationResult.Data, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }

            throw new InvalidOperationException(string.Join(";", opreationResult.Errors));
        }

        public static string GetSystemLoginUrl(this Controller controller)
        {
            return controller.Url.Action("Index", "Login", controller.Request.Url.Scheme);
        }
    }
}