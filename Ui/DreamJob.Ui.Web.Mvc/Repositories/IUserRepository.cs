namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    public interface IUserRepository
    {
        DjOperationResult<User> FindUserByLoginAndPasswordHash(string login, string passwordHash);
        DjOperationResult<bool> UpdateLastLoginData(long userId);
        DjOperationResult<User> GetUser(long userId);
    }
}