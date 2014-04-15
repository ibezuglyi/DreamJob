using DreamJob.Domain.Models;

using System.Data.Entity;

namespace DreamJob.Repositories
{
    public class JobContext : DbContext
    {
        public JobContext()
            : base("dreamjob")
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<User> Users { get; set; }

        internal void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
