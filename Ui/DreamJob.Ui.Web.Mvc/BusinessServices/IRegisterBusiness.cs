using System.Web.Mvc;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IRegisterBusiness
    {
        DjOperationResult<UserRegistrationViewModel> GetRegisterViewModel();
        DjOperationResult<string> RegisterDeveloper(UserRegistrationDto model, UrlHelper url, string scheme);
        DjOperationResult<string> RegisterRecruiter(UserRegistrationDto model, UrlHelper url, string scheme);
        void ConfirmUserRegistration(string hash);
        bool IsEmailUnique(string email);
        bool IsDisplayNameUnique(string displayName);
        bool IsLoginUnique(string login);
    }
}