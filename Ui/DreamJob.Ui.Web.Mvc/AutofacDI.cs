namespace DreamJob.Ui.Web.Mvc
{
    using System.Reflection;

    using Autofac;
    using Autofac.Integration.Mvc;

    using DreamJob.Database.EntityFramework;
    using DreamJob.Ui.Web.Mvc.BusinessServices;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Helpers;
    using DreamJob.Ui.Web.Mvc.Repositories;
    using DreamJob.Ui.Web.Mvc.Services;

    public class AutofacDI
    {
        public static IContainer AutofacInitialize()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterControllers(Assembly.GetCallingAssembly());

            containerBuilder.RegisterType<RegisterBusiness>().As<IRegisterBusiness>();
            containerBuilder.RegisterType<LoginBusiness>().As<ILoginBusiness>();
            containerBuilder.RegisterType<OffersBusiness>().As<IOffersBusiness>();

            containerBuilder.RegisterType<RegisterService>().As<IRegisterService>();
            containerBuilder.RegisterType<OfferService>().As<IOfferService>();
            containerBuilder.RegisterType<RecruiterService>().As<IRecruiterService>();

            containerBuilder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();
            containerBuilder.RegisterType<RecruiterRepository>().As<IRecruiterRepository>();
            
            containerBuilder.RegisterType<OffersRepository>().As<IOffersRepository>();

            containerBuilder.RegisterType<Md5PasswordHasher>().As<IPasswordHasher>();
            containerBuilder.RegisterType<DateTimeAdapter>().As<IDateTimeAdapter>();




            containerBuilder.RegisterType<CommentsBusiness>().As<ICommentBusiness>();
            containerBuilder.RegisterType<CommentService>().As<ICommentService>();
            containerBuilder.RegisterType<CommentsRepository>().As<ICommentsRepository>();




            containerBuilder.RegisterType<FormAuthentication>().As<IAuthentication>();
            containerBuilder.RegisterType<LoginService>().As<ILoginService>();
            containerBuilder.RegisterType<Session>().As<ISession>();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<LogoffBusiness>().As<ILogoffBusiness>();
            containerBuilder.RegisterType<ProfileBusiness>().As<IProfileBusiness>();

            containerBuilder.RegisterType<DeveloperBusiness>().As<IDeveloperBusiness>();
            containerBuilder.RegisterType<DeveloperService>().As<IDeveloperService>();
            containerBuilder.RegisterType<DeveloperRepository>().As<IDeveloperRepository>();

            containerBuilder.RegisterType<DreamJobContext>().InstancePerRequest();


            var container = containerBuilder.Build();
            return container;
        }
    }
}