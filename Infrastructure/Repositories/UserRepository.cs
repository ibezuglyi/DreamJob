namespace DreamJob.Infrastructure.Repositories
{
    using System.Linq;

    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Infrastructure.Repositories.Base;
    using DreamJob.Repositories;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(JobContext context)
            : base(context)
        {
        }

        public User FindUserByLoginAndHash(string login, string passwordHash)
        {
            var user =
                this.Context.Users
                    .Where(x => x.Login == login)
                    .FirstOrDefault(x => x.PasswordHash == passwordHash);

            return user;

        }

        public bool UserExists(string login, string passwordHash)
        {
            var user = this.Context.Users
                .Where(x => x.Login == login)
                .Where(x => x.PasswordHash == passwordHash)
                .Count();

            return user == 1;
        }
    }
}
