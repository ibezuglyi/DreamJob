using System.Collections.Generic;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IProfileBusiness
    {
        DjOperationResult<UserProfileDto> GetCurrentUserProfile();
        DjOperationResult<List<string>> GetDeveloperCities(string cityPart);
        DjOperationResult<List<DeveloperProfileDto>> SearchForDevelopers(string technology, string city);

        DjOperationResult<bool> UpdateRecruiterProfile(SaveRecruiterProfileDto model);
        DjOperationResult<bool> UpdateDeveloperProfile(Controllers.SaveDeveloperProfileDto model);
    }
}