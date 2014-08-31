using System.Data.Entity.Migrations;
using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Models.Dto;

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

        public DjOperationResult<Recruiter> GetRecruiterById(long id)
        {
            var recruiter = context.Recruiters.SingleOrDefault(r => r.Id == id);
            if (recruiter == null)
            {
                return new DjOperationResult<Recruiter>(false, new[] { "Recruiter not found" });
            }
            return new DjOperationResult<Recruiter>(recruiter);

        }

        public void UpdateRecruiterProfile(Recruiter recruiter)
        {
            context.Recruiters.AddOrUpdate(recruiter);
            context.SaveChanges();
        }
    }
}