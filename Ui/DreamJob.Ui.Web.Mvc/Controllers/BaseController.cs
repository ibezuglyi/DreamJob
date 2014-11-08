using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DreamJob.Ui.Web.Mvc.BusinessServices;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    public class BaseController : Controller
    {
        private readonly IEmailService emailService;

        public BaseController(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
            emailService.NotifyNewErrorOccurs(filterContext.Exception);
            Redirect("~/Views/Shared/Error.cshtml");
        }
    }
}