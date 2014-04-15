namespace DreamJob.Infrastructure.Repositories
{
    using System.Data.Entity;

    using DreamJob.Domain.Models;

    public class DreamJobContext : DbContext, IDreamJobContext
    {
        public void Save()
        {
            this.SaveChanges();
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Candidate> Candidates { get; set; }
    }
}