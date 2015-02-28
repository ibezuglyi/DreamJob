namespace DreamJob.Migrations
{
    using System.Data.Entity.Migrations;

    using DreamJob.Models;
    using DreamJob.ViewModels;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDatabase>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDatabase context)
        {
            context.Roles.Add(new Role { RoleName = ApplicationUserRole.Recruiter.ToString(),
                                         RoleId = (int)ApplicationUserRole.Recruiter });
            
            context.Roles.Add(new Role { RoleName = ApplicationUserRole.Developer.ToString(), 
                                         RoleId = (int)ApplicationUserRole.Developer });
            context.SaveChanges();
        }
    }
}
