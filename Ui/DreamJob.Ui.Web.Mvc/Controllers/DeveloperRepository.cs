namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    class DeveloperRepository : IDeveloperRepository
    {
        private readonly DreamJobContext context;

        public DeveloperRepository(DreamJobContext context)
        {
            this.context = context;
        }

        public void Add(Developer developer)
        {
            this.context.Developers.Add(developer);
            this.context.SaveChanges();
        }
    }
}