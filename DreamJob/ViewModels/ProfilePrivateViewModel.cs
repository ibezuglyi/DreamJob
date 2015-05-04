namespace DreamJob.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Dtos;

    public class ProfilePrivateViewModel
    {
        public ProfilePrivateViewModel(
            ProfilePrivateDeveloperEditDto developerDto,
            ProfilePrivateRecruiterDto recruiterDto,
            ApplicationUserRole loggedInUserRole)
        {
            this.LoggedInUserRole = loggedInUserRole;
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
            : this(new ProfilePrivateDeveloperEditDto(), new ProfilePrivateRecruiterDto(), ApplicationUserRole.Anonymous)
        { }

        public ProfilePrivateViewModel(ProfilePrivateDeveloperEditDto dto)
            : this(dto, new ProfilePrivateRecruiterDto(), ApplicationUserRole.Developer)
        { }

        public ProfilePrivateViewModel(ProfilePrivateRecruiterDto dto)
            : this(new ProfilePrivateDeveloperEditDto(), dto, ApplicationUserRole.Recruiter)
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