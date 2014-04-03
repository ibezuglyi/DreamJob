
namespace DreamJob.Infrastructure.Repositories
{
    using DreamJob.Domain.Models;
    using DreamJob.Interfaces;
    

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
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
