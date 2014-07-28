using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    internal interface IRegisterService
    {
        DjOperationResult<string> AddNewDeveloper(UserRegistrationDto model);
        DjOperationResult<string> AddNewRecruiter(UserRegistrationDto model);
        void ConfirmUserRegistration(string hash);
    }
}