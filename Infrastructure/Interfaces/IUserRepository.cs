namespace DreamJob.Infrastructure.Interfaces
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;

    public interface IUserRepository : IBaseRepository<User>
    {
        void Insert(User userData);
        User FindUserByLoginAndHash(string login, string passwordHash);
    }
}