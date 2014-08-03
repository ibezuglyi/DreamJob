﻿using System.Linq;
using DreamJob.Database.EntityFramework;
using DreamJob.Model.Domain;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
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

        public void ConfirmRecruterRegistration(string hash)
        {
            var recruter = this.context.Recruiters.SingleOrDefault(r => r.Confirmations.Any(t=>t.ConfirmationCode == hash));
            if (recruter != null)
            {
                context.Entry(recruter).Collection(r => r.Confirmations).Load();
                var confirmation = recruter.Confirmations.Single(r => r.ConfirmationCode == hash);
                recruter.Confirmations.Remove(confirmation);
                recruter.IsActive = true;
                this.context.SaveChanges();
            }
        }
    }
}