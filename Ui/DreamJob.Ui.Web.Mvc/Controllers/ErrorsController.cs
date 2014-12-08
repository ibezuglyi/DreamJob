using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DreamJob.Ui.Web.Mvc.BusinessServices;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    public class ErrorsController : Controller
    {
        private readonly string errorPage;
        private const string errorHeaderName ="x-error";

        public ErrorsController()
        {
        }

        public ActionResult Index()
        {
            HttpContext.Response.AddHeader(errorHeaderName, Url.Action("Index", "Errors"));
            return View();
            
        }

        public ActionResult InternalError()
        {
            HttpContext.Response.AddHeader(errorHeaderName, Url.Action("Index", "Errors"));
            return View();
        }

        public ActionResult NotFound()
        {
            HttpContext.Response.AddHeader(errorHeaderName, Url.Action("Index", "Errors"));
            return View();
        }

    }
}