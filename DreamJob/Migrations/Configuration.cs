namespace DreamJob.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Web.Security;

    using DreamJob.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDatabase>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDatabase context)
        {
            Roles.CreateRole("Developer");
            Roles.CreateRole("Recruiter");
        }
    }
}
