using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    internal interface IRegisterService
    {
        DjOperationResult<bool> AddNewDeveloper(UserRegistrationDto model);
        DjOperationResult<bool> AddNewRecruiter(UserRegistrationDto model);
    }
}