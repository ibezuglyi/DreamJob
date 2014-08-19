namespace DreamJob.Ui.Web.Mvc.Services
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface ILoginService
    {
        DjOperationResult<bool> LoginUser(LoginUserDto data);
    }
}