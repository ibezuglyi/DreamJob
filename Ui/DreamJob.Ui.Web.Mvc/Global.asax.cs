using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DreamJob.Ui.Web.Mvc.BusinessServices;
using DreamJob.Ui.Web.Mvc.Helpers;
using DreamJob.Ui.Web.Mvc.Models.Dto;
using DreamJob.Ui.Web.Mvc.Repositories;
using DreamJob.Ui.Web.Mvc.Services;

namespace DreamJob.Ui.Web.Mvc
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    using DreamJob.Database.EntityFramework;

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

        
    }
}
