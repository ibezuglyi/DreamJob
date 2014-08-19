namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;

    public interface IProfileBusiness
    {
        DjOperationResult<UserProfileDto> GetCurrentUserProfile();
    }
}