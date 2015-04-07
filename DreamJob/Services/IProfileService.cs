namespace DreamJob.Services
{
    using Dtos;
    using ViewModels;

    public interface IProfileService
    {
        ProfilePublicViewModel GetPublicDataForUserId(long id);
        ProfilePublicViewModel GetPublicDataForLoggedUser();
        ProfilePrivateViewModel GetPrivateDataForLoggedUser();

        void UpdateDeveloperProfile(ProfilePrivateDeveloperEditDto dto);
        void UpdateRecruiterProfile(ProfilePrivateRecruiterDto dto);


        void UpdateDeveloperProfile(ProfilePrivateDeveloperEditDto updateProfile, long id);
        void UpdateRecruiterProfile(ProfilePrivateRecruiterDto updateProfile, long id);


        void RemoveSkillFromProfile(long skillId);

        HomeIndexViewModel GetDevelopersHeadlines();

        SearchResultViewModel GetDevelopersHeadlinesWithSkill(SearchSkillDto dto);
        SearchResultViewModel GetDevelopersHeadlinesWithSalaryInRange(SearchSalaryDto dto);
    }
}