namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IProfileBusiness
    {
        DjOperationResult<UserProfileDto> GetCurrentUserProfile();
        DjOperationResult<bool> UpdateProfile(UserProfileDto profile);
    }
}