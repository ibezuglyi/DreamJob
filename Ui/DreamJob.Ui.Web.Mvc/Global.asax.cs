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
    }
}
