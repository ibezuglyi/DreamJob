namespace DreamJob.Ui.Web.Mvc
{
    using System.Linq;

    using DreamJob.Common.Enum;
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Controllers;

    class UserRepository : IUserRepository
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
            var user =
                this.context.Users
                    .Where(x => x.Login == login)
                    .SingleOrDefault(x => x.PasswordHash == passwordHash);
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
    }
}