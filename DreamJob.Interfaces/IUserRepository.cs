
namespace DreamJob.Interfaces
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;

    public interface IUserRepository : IBaseRepository<User>
    {
        void Insert(object userData);
        void Find(object recruiterLoginData);
    }
}