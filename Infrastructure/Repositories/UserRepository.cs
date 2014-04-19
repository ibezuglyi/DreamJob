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

        public UserPublicData GetUserPublicDataByLoginAndHash(string login, string passwordHash)
        {
            var user =
                this.Context.Users
                    .Where(x => x.Login == login)
                    .FirstOrDefault(x => x.PasswordHash == passwordHash);

            var result = new UserPublicData { AccountType = user.AccountType, Id = user.Id, Login = user.Login };

            return result;
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
