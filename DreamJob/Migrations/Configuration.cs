namespace DreamJob.Migrations
{
    using System.Data.Entity.Migrations;

    using DreamJob.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDatabase>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDatabase context)
        {
            context.Roles.Add(new Role { RoleName = "Developer" });
            context.Roles.Add(new Role { RoleName = "Recruiter" });
            context.SaveChanges();
        }
    }
}
