namespace DreamJob.Infrastructure.Repositories
{
    using System.Data.Entity;

    using DreamJob.Domain.Models;

    public interface IDreamJobContext
    {
        void Save();
        IDbSet<User> Users { get; set; }
        IDbSet<Candidate> Candidates{ get; set; }
    }
}