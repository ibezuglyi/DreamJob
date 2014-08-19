namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using System.Linq;

    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    public class DeveloperRepository : IDeveloperRepository
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

        public void ConfirmDeveloperRegistration(string hash)
        {
            var developer = this.context.Developers.SingleOrDefault(r => r.Confirmations.Any(t => t.ConfirmationCode == hash));
            if (developer != null)
            {
                this.context.Entry(developer).Collection(r => r.Confirmations).Load();
                var confirmation = developer.Confirmations.Single(r => r.ConfirmationCode == hash);
                developer.Confirmations.Remove(confirmation);
                developer.IsActive = true;
                this.context.SaveChanges();
            }
        }
    }
}