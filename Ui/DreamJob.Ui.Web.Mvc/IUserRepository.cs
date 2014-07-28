namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;

    internal interface IUserRepository
    {
        DjOperationResult<User> FindUserByLoginAndPasswordHash(string login, string passwordHash);
    }
}