
namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Interfaces;
    using DreamJob.Repositories;
    

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(JobContext context)
            : base(context)
        {

        }
        public void Insert(object userData)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }

        public void Find(object recruiterLoginData)
        {
            throw new System.NotImplementedException();
        }
    }
}
