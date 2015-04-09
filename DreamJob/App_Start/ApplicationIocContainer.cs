using System.Web.Mvc;

using Autofac;
using Autofac.Integration.Mvc;

using DreamJob.Infrastructure;
using DreamJob.Models;
using DreamJob.Services;

namespace DreamJob
{


    public static class ApplicationIocContainer
    {
        public static IContainer Container { get; private set; }

        public static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ProfileService>().As<IProfileService>();
            builder.RegisterType<JobOfferService>().As<IJobOfferService>();
            builder.RegisterType<MenuService>().As<IMenuService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<TestService>().As<ITestService>();
            builder.RegisterType<WebSecurityAccountService>().As<IAccountService>();

            builder.RegisterType<ApplicationDatabase>().InstancePerLifetimeScope();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));
        }
    }
}