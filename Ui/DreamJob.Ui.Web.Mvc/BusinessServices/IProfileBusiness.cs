using System.Collections.Generic;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IProfileBusiness
    {
        DjOperationResult<UserProfileDto> GetCurrentUserProfile();
        DjOperationResult<bool> UpdateDeveloperProfile(long id, UserProfileDto profile);
        DjOperationResult<bool> UpdateRecruiterProfile(long id, UserProfileDto profile);
        DjOperationResult<List<string>> GetDeveloperCities(string cityPart);
        DjOperationResult<List<DeveloperProfileDto>> SearchForDevelopers(string technology, string city);
    }
}