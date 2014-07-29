﻿namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using DreamJob.Common.Enum;

    public interface IProfileBusiness
    {
        DjOperationResult<UserProfileDto> GetCurrentUserProfile();
    }

    class ProfileBusiness : IProfileBusiness
    {
        private readonly ISession session;

        private readonly IUserService userService;

        public ProfileBusiness(ISession session, IUserService userService)
        {
            this.session = session;
            this.userService = userService;
        }

        public DjOperationResult<UserProfileDto> GetCurrentUserProfile()
        {
            var getCurrentUserResult = this.session.GetCurrentUser();
            if (getCurrentUserResult.IsSuccess == false)
            {
                return new DjOperationResult<UserProfileDto>(false, getCurrentUserResult.Errors);
            }

            var currentUserProfile = this.userService.GetFullUserProfile(getCurrentUserResult.Data.Id);
            return currentUserProfile;
        }
    }
}