namespace DreamJob.Infrastructure.Repositories
{
    using System.Linq;

    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Repositories;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(JobContext context)
            : base(context)
        {
        }

        public void Insert(User userData)
        {
            this.Context.Users.Add(userData);
            this.Context.Save();
        }

        public User FindUserByLoginAndHash(string login, string passwordHash)
        {
            var user =
                this.Context.Users
                    .Where(x => x.Login == login)
                    .FirstOrDefault(x => x.PasswordHash == passwordHash);

            return user;

        }
    }
}
