﻿namespace DreamJob
{
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.Security;

    using WebMatrix.WebData;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ApplicationIocContainer.Initialize();
            ApplicationMapper.Initialize();

            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserAccounts", "Id", "Email", false);
        }
    }
}
