namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    internal interface IRegisterService
    {
        DjOperationResult<bool> AddNewDeveloper(RegisterUserViewModel model);
        DjOperationResult<bool> AddNewRecruiter(RegisterUserViewModel model);
    }
}