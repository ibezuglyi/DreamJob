namespace DreamJob.ViewModels
{
    using System;
    using System.Collections.Generic;

    using DreamJob.Dtos;

    public class ProfilePrivateViewModel
    {
        public ProfilePrivateViewModel(ProfilePrivateDeveloperEditDto developerDto, ProfilePrivateRecruiterDto recruiterDto)
        {
            this.Developer = new ProfilePrivateDeveloperViewModel(developerDto);
            this.Recruiter = new ProfilePrivateRecruiterViewModel(recruiterDto);

            this.FormActionLinkForUserRole =
                             new Dictionary<ApplicationUserRole, Func<string>>
                                 {
                                     {ApplicationUserRole.Developer, ()=>this.FormActionUpdateDeveloper},
                                     {ApplicationUserRole.Recruiter, ()=>this.FormActionUpdateRecruiter}
                                 };
        }

        public ProfilePrivateViewModel()
            : this(new ProfilePrivateDeveloperEditDto(), new ProfilePrivateRecruiterDto())
        { }

        public ProfilePrivateViewModel(ProfilePrivateDeveloperEditDto dto)
            : this(dto, new ProfilePrivateRecruiterDto())
        { }

        public ProfilePrivateViewModel(ProfilePrivateRecruiterDto dto)
            : this(new ProfilePrivateDeveloperEditDto(), dto)
        { }

        public ProfilePrivateDeveloperViewModel Developer { get; set; }
        public ProfilePrivateRecruiterViewModel Recruiter { get; set; }

        public ApplicationUserRole LoggedInUserRole { get; set; }
        public string FormActionUpdateDeveloper { get; set; }
        public string FormActionUpdateRecruiter { get; set; }

        public Dictionary<ApplicationUserRole, Func<string>> FormActionLinkForUserRole { get; set; }

        public string GetCurrentUserFormActionUrl()
        {
            return this.FormActionLinkForUserRole[this.LoggedInUserRole]();
        }
    }
}