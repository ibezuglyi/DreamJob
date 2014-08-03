using DreamJob.Common.Enum;
using DreamJob.Ui.Web.Mvc.Models;
using DreamJob.Ui.Web.Mvc.Models.Dto;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    public interface IRegisterBusiness
    {
        DjOperationResult<UserRegistrationViewModel> GetRegisterViewModel();
        DjOperationResult<string> RegisterDeveloper(UserRegistrationDto model);
        DjOperationResult<string> RegisterRecruiter(UserRegistrationDto model);
        void ConfirmUserRegistration(string hash);
    }
}