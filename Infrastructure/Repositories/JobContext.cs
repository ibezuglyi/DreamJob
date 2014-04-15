using DreamJob.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DbSet<Recruiter> Recruiter { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

    }
}
