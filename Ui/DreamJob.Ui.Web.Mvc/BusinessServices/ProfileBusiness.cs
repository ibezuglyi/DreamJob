using System.Collections.Generic;

namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Controllers;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Services;

    public class ProfileBusiness : IProfileBusiness
    {
        private readonly ISession session;

        private readonly IUserService userService;
        private readonly IDeveloperService developerService;

        public ProfileBusiness(ISession session, IUserService userService, IDeveloperService developerService)
        {
            this.session = session;
            this.userService = userService;
            this.developerService = developerService;
        }

        public DjOperationResult<UserProfileDto> GetCurrentUserProfile()
        {
            var getCurrentUserResult = this.session.GetCurrentUser();
            if (getCurrentUserResult.IsSuccess == false)
            {
                return new DjOperationResult<UserProfileDto>(false, getCurrentUserResult.Errors);
            }
            UserProfileDto currentUserProfile = null;
            if(getCurrentUserResult.Data.AccountType == UserAccountType.Developer)
                currentUserProfile = this.developerService.GetDeveloperPublicProfile(getCurrentUserResult.Data.Id).Data;
            else
            {
                
            }
            return new DjOperationResult<UserProfileDto>(currentUserProfile);
        }

        public DjOperationResult<bool> UpdateDeveloperProfile(long id, UserProfileDto profile)
        {
            this.developerService.UpdateDeveloper(id, profile);
            return new DjOperationResult<bool>(true);
        }

        public DjOperationResult<List<string>> GetDeveloperCities(string cityPart)
        {
            var result = developerService.GetDeveloperCities(cityPart);
            return new DjOperationResult<List<string>>(result);
        }
    }
}