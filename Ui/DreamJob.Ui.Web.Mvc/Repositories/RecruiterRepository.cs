namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using System.Linq;

    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    public class RecruiterRepository : IRecruiterRepository
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

        public void ConfirmRecruiterRegistration(string hash)
        {
            var recruiter = this.context.Recruiters.SingleOrDefault(r => r.Confirmations.Any(t => t.ConfirmationCode == hash));
            if (recruiter != null)
            {
                this.context.Entry(recruiter).Collection(r => r.Confirmations).Load();
                var confirmation = recruiter.Confirmations.Single(r => r.ConfirmationCode == hash);
                recruiter.Confirmations.Remove(confirmation);
                recruiter.IsActive = true;
                this.context.SaveChanges();
            }
        }
    }
}