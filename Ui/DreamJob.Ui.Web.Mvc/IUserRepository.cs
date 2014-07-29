namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    internal interface IUserRepository
    {
        DjOperationResult<User> FindUserByLoginAndPasswordHash(string login, string passwordHash);

        DjOperationResult<bool> UpdateLastLoginData(long userId);

        DjOperationResult<User> GetUser(long userId);
    }
}