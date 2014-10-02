namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using System.Linq;

    using DreamJob.Common.Enum;
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Helpers;

    public class UserRepository : IUserRepository
    {
        private readonly DreamJobContext context;

        private readonly IDateTimeAdapter dateTimeAdapter;

        public UserRepository(DreamJobContext context, IDateTimeAdapter dateTimeAdapter)
        {
            this.context = context;
            this.dateTimeAdapter = dateTimeAdapter;
        }

        public DjOperationResult<User> FindUserByLoginAndPasswordHash(string login, string passwordHash)
        {
            var user = this.context.Users.SingleOrDefault(x =>
                                    x.Login == login &&
                                    x.PasswordHash == passwordHash &&
                                    x.IsActive);

            var result = new DjOperationResult<User>(user);
            return result;
        }

        public DjOperationResult<bool> UpdateLastLoginData(long userId)
        {
            var user = this.context.Users.Single(x => x.Id == userId);
            user.LastLoginDateTime = this.dateTimeAdapter.Now;
            this.context.SaveChanges();
            return DjOperationResult<bool>.Success();
        }

        public DjOperationResult<User> GetUser(long userId)
        {
            var user = this.context.Users.SingleOrDefault(x => x.Id == userId);
            var result = new DjOperationResult<User>(user);

            return result;
        }

        public DjOperationResult<User> FindUserByLogin(string login)
        {
            var user = this.context.Users.SingleOrDefault(x => x.Login == login);
            var result = new DjOperationResult<User>(user);
            return result;
        }
    }
}