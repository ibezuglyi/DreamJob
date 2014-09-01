namespace DreamJob.Ui.Web.Mvc.BusinessServices
{
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Services;

    public class ProfileBusiness : IProfileBusiness
    {
        private readonly ISession session;

        private readonly IUserService userService;
        private readonly IDeveloperService developerService;
        private readonly IRecruiterService recruiterService;

        public ProfileBusiness(
            ISession session,
            IUserService userService,
            IDeveloperService developerService,
            IRecruiterService recruiterService)
        {
            this.session = session;
            this.userService = userService;
            this.developerService = developerService;
            this.recruiterService = recruiterService;
        }

        public DjOperationResult<UserProfileDto> GetCurrentUserProfile()
        {
            var getCurrentUserResult = this.session.GetCurrentUser();
            if (getCurrentUserResult.IsSuccess == false)
            {
                return new DjOperationResult<UserProfileDto>(false, getCurrentUserResult.Errors);
            }
            var currentUserProfile = GetUserProfile(getCurrentUserResult.Data);
            return new DjOperationResult<UserProfileDto>(currentUserProfile);
        }

        private UserProfileDto GetUserProfile(LoginUserDto loginUserDto)
        {
            UserProfileDto currentUserProfile = null;
            if (loginUserDto.AccountType == UserAccountType.Developer)
            {
                currentUserProfile = this.developerService.GetDeveloperPublicProfile(loginUserDto.Id).Data;
            }
            else
            {
                currentUserProfile = this.recruiterService.GetRecruiterPublicProfile(loginUserDto.Id).Data;
            }
            return currentUserProfile;
        }

        public DjOperationResult<bool> UpdateDeveloperProfile(long id, UserProfileDto profile)
        {
            this.developerService.UpdateDeveloper(id, profile);
            return new DjOperationResult<bool>(true);
        }

        public DjOperationResult<bool> UpdateRecruiterProfile(long id, UserProfileDto profile)
        {
            this.recruiterService.UpdateRecruiterProfile(id, profile);
            return new DjOperationResult<bool>(true);
        }

        public DjOperationResult<List<string>> GetDeveloperCities(string cityPart)
        {
            var result = developerService.GetDeveloperCities(cityPart);
            return new DjOperationResult<List<string>>(result);
        }

        public DjOperationResult<List<DeveloperProfileDto>> SearchForDevelopers(string technology, string city)
        {
            var result = developerService.SearchForDevelopers(technology, city);
            return new DjOperationResult<List<DeveloperProfileDto>>(result);

        }
    }
}