namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface IRegisterBusiness
    {
        DjOperationResult<RegisterUserViewModel> GetRegisterViewModel();

        DjOperationResult<bool> RegisterDeveloper(RegisterUserViewModel model);

        DjOperationResult<bool> RegisterRecruiter(RegisterUserViewModel model);
    }
}