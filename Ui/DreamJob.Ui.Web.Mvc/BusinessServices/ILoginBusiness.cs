using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public interface ILoginBusiness
    {
        DjOperationResult<LoginDto> GetLoginViewModel();

        DjOperationResult<bool> LoginUser(LoginDto model);
    }
}