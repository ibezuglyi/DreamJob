using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DreamJob.Ui.Web.Mvc.Startup))]
namespace DreamJob.Ui.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
