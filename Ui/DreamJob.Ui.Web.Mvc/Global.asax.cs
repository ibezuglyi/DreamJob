using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = AutofacInitialize();
            var autofacDependencyResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(autofacDependencyResolver);

            InitializeAutomapper();
        }

        private void InitializeAutomapper()
        {
            AutoMapper.Mapper.CreateMap<UserRegistrationDto, Developer>()
                .ForMember(r=>r.Edit, o=>o.UseValue(DateTime.Now))
                .ForMember(r=>r.Add, o=>o.UseValue(DateTime.Now));
            AutoMapper.Mapper.CreateMap<UserRegistrationDto, Recruiter>()
                .ForMember(r => r.Edit, o => o.UseValue(DateTime.Now))
                .ForMember(r => r.Add, o => o.UseValue(DateTime.Now));

            AutoMapper.Mapper.CreateMap<User, LoginUserDto>();
            AutoMapper.Mapper.CreateMap<User, UserProfileDto>();
        }

        public static IContainer AutofacInitialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetCallingAssembly());

            containerBuilder.RegisterType<RegisterBusiness>().As<IRegisterBusiness>();
            containerBuilder.RegisterType<LoginBusiness>().As<ILoginBusiness>();
            containerBuilder.RegisterType<RegisterService>().As<IRegisterService>();
            containerBuilder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();
            containerBuilder.RegisterType<Md5PasswordHasher>().As<IPasswordHasher>();
            containerBuilder.RegisterType<RecruiterRepository>().As<IRecruiterRepository>();
            containerBuilder.RegisterType<DateTimeAdapter>().As<IDateTimeAdapter>();




            containerBuilder.RegisterType<FormAuthentication>().As<IAuthentication>();
            containerBuilder.RegisterType<LoginService>().As<ILoginService>();
            containerBuilder.RegisterType<Session>().As<ISession>();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<LogoffBusiness>().As<ILogoffBusiness>();
            containerBuilder.RegisterType<ProfileBusiness>().As<IProfileBusiness>();
            
            
            
            
            containerBuilder.RegisterType<DreamJobContext>().InstancePerRequest();


            var container= containerBuilder.Build();
            return container;
        }
    }
}
