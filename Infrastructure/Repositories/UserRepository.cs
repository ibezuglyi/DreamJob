namespace DreamJob.Infrastructure.Repositories
{
    using System.Linq;

    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;

    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IDreamJobContext context)
            : base(context)
        {
        }

        public void Insert(User userData)
        {
            this.context.Users.Add(userData);
            this.context.Save();
        }

        public User FindUserByLoginAndHash(string login, string passwordHash)
        {
            var user =
                this.context.Users
                    .Where(x => x.Login == login)
                    .FirstOrDefault(x => x.PasswordHash == passwordHash);

            return user;

        }

        public void Find(object recruiterLoginData)
        {
            throw new System.NotImplementedException();
        }
    }
}
