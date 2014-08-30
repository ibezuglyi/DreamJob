using System.Data.Entity.Migrations;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using DreamJob.Common.Enum;
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

        public DjOperationResult<List<Developer>> All()
        {
            var all = this.context.Developers.ToList();
            var operationResult = new DjOperationResult<List<Developer>>(all);
            return operationResult;
        }

        public DjOperationResult<Developer> GetById(long developerId)
        {
            var developer = this.context.Developers.SingleOrDefault(d => d.DeveloperId == developerId);
            var result = new DjOperationResult<Developer>(developer);
            return result;
        }

        public void UpdateDeveloper(Developer developer)
        {
            context.Developers.AddOrUpdate(developer);
            context.SaveChanges();
        }
    }
}