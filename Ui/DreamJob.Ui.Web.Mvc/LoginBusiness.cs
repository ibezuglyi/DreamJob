namespace DreamJob.Ui.Web.Mvc
{
    using System;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public class LoginBusiness:ILoginBusiness
    {
        public DjOperationResult<LoginDTO> GetLoginViewModel()
        {
            var model = new LoginDTO();
            var result = new DjOperationResult<LoginDTO>(model);
            return result;
        }
    }
}