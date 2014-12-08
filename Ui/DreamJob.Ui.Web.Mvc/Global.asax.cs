using System;
using System.Net;
using System.Security.Policy;
using System.Web;
using DreamJob.Ui.Web.Mvc.BusinessServices;

namespace DreamJob.Ui.Web.Mvc
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Autofac.Integration.Mvc;

    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = AutofacDI.AutofacInitialize();

            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);

            DjAutoMapper.InitializeAutomapper();


            GlobalFilters.Filters.Add(new ResetSessionWhenOutOfSyncWithForms());

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var errorsBusiness = AutofacDependencyResolver.Current.GetService(typeof(IErrorsBusiness)) as IErrorsBusiness;
            if (exception != null && errorsBusiness != null)
            {
                errorsBusiness.SendEmailOnInternalError(exception);
            }
            

        }

    }
}
