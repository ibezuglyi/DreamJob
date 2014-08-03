﻿using System;
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
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Areas.Api.Controllers;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            var container = AutofacInitialize();

            var mvcResolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(mvcResolver);



            InitializeAutomapper();
            
            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
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

            AutoMapper.Mapper.CreateMap<JobOffer, JobOfferDto>();
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
            containerBuilder.RegisterType<OffersLogic>().As<IOffersLogic>();
            containerBuilder.RegisterType<OfferService>().As<IOfferService>();
            containerBuilder.RegisterType<OffersRepository>().As<IOffersRepository>();




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
