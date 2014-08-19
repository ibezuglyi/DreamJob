namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface ILoginBusiness
    {
        DjOperationResult<LoginDto> GetLoginViewModel();

        DjOperationResult<bool> LoginUser(LoginDto model);
    }
}