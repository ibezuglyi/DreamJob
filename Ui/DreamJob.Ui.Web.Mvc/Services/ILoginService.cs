using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Services
{
    public interface ILoginService
    {
        DjOperationResult<bool> LoginUser(LoginUserDto data);
    }
}