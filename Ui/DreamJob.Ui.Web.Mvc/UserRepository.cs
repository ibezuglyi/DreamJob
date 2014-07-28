namespace DreamJob.Ui.Web.Mvc
{
    using System.Linq;

    using DreamJob.Common.Enum;
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    class UserRepository : IUserRepository
    {
        private readonly DreamJobContext context;

        public UserRepository(DreamJobContext context)
        {
            this.context = context;
        }

        public DjOperationResult<User> FindUserByLoginAndPasswordHash(string login, string passwordHash)
        {
            var user = this.context.Users.Where(x => x.Login == login).Where(x => x.PasswordHash == passwordHash).SingleOrDefault();
            var result = new DjOperationResult<User>(user);
            return result;
        }
    }
}