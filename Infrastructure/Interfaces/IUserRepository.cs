namespace DreamJob.Infrastructure.Interfaces
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces.Base;

    public interface IUserRepository : IBaseRepository<User>
    {
        User FindUserByLoginAndHash(string login, string passwordHash);

        bool UserExists(string p1, string p2);
    }
}