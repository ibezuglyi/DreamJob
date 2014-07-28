namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface ILoginBusiness
    {
        DjOperationResult<LoginDTO> GetLoginViewModel();

        DjOperationResult<bool> LoginUser(LoginDTO model);
    }
}