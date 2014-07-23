namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    class RecruiterRepository : IRecruiterRepository
    {
        private readonly DreamJobContext context;

        public RecruiterRepository(DreamJobContext context)
        {
            this.context = context;
        }

        public void Add(Recruiter recruiter)
        {
            this.context.Recruiters.Add(recruiter);
            this.context.SaveChanges();
        }
    }
}