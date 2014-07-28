namespace DreamJob.Ui.Web.Mvc
{
    using DreamJob.Common.Enum;

    public interface IUserService
    {
        DjOperationResult<LoginUserDto> GetUserLoginDto(string login, string passwordHash);
    }
}