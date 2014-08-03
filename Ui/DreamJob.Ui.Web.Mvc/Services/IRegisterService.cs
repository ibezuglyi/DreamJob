using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.Services
{
    internal interface IRegisterService
    {
        DjOperationResult<string> AddNewDeveloper(UserRegistrationDto model);
        DjOperationResult<string> AddNewRecruiter(UserRegistrationDto model);
        void ConfirmUserRegistration(string hash);
    }
}