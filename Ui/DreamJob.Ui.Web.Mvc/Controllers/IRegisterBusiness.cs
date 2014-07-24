using DreamJob.Ui.Web.Mvc.Models;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface IRegisterBusiness
    {
        DjOperationResult<UserRegistrationViewModel> GetRegisterViewModel();
        DjOperationResult<bool> RegisterDeveloper(UserRegistrationDto model);
        DjOperationResult<bool> RegisterRecruiter(UserRegistrationDto model);
    }
}