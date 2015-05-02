namespace DreamJob
{
    using System.Linq;
    using ValueResolvers;

    using AutoMapper;

    using Dtos;
    using Infrastructure;
    using Models;
    using ViewModels;

    public static class ApplicationMapper
    {
        public static void Initialize()
        {
            ToViewModel();
            ToEntity();
            ToDto();
            Mapper.CreateMap<UserAccount, ApplicationUser>();

            Mapper.AssertConfigurationIsValid();
        }

        private static void ToDto()
        {
            Mapper.CreateMap<JobOfferStatusChangeDto, JobOfferRejectDto>();
            Mapper.CreateMap<JobOfferStatusChangeDto, JobOfferCancelDto>();
            Mapper.CreateMap<JobOfferStatusChangeDto, JobOfferAcceptDto>();
            Mapper.CreateMap<JobOfferStatusChangeDto, JobOfferConfirmDto>();
        }

        private static void ToEntity()
        {
            Mapper.CreateMap<ContactInformationDto, ContactInformation>()
                .ForMember(d => d.JobOfferStatusChange, o => o.Ignore())
                .ForMember(d => d.JobOfferStatusChangeId, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreateDateTime, o => o.Ignore());

            Mapper.CreateMap<ProfileRegisterDto, UserAccount>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.PasswordHash, o => o.Ignore())
                .ForMember(d => d.Developer, o => o.Ignore())
                .ForMember(d => d.Recruiter, o => o.Ignore())
                .ForMember(d => d.CreateDateTime, o => o.Ignore());

            Mapper.CreateMap<JobOfferSendDto, JobOffer>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Developer, o => o.Ignore())
                .ForMember(d => d.Developer, o => o.Ignore())
                .ForMember(d => d.RecruiterId, o => o.Ignore())
                .ForMember(d => d.Recruiter, o => o.Ignore())
                .ForMember(d => d.JobOfferComments, o => o.Ignore())
                .ForMember(d => d.Statuses, o => o.Ignore())
                .ForMember(d => d.NewMessagesToRead, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreateDateTime, o => o.Ignore());

            Mapper.CreateMap<CommentAddDto, JobOfferComment>()
                .ForMember(d => d.AuthorId, o => o.Ignore())
                .ForMember(d => d.Author, o => o.Ignore())
                .ForMember(d => d.AuthorRole, o => o.Ignore())
                .ForMember(d => d.JobOffer, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreateDateTime, o => o.Ignore());

            Mapper.CreateMap<JobOfferRejectDto, JobOfferStatusChange>()
                .ForMember(d => d.Status, o => o.UseValue(JobOfferStatus.Rejected))
                .ForMember(d => d.AuthorId, o => o.Ignore())
                .ForMember(d => d.AuthorRole, o => o.Ignore())
                .ForMember(d => d.ContactInformation, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreateDateTime, o => o.Ignore());

            Mapper.CreateMap<JobOfferCancelDto, JobOfferStatusChange>()
                .ForMember(d => d.Status, o => o.UseValue(JobOfferStatus.Canceled))
                .ForMember(d => d.AuthorId, o => o.Ignore())
                .ForMember(d => d.AuthorRole, o => o.Ignore())
                .ForMember(d => d.ContactInformation, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreateDateTime, o => o.Ignore());

            Mapper.CreateMap<JobOfferConfirmDto, JobOfferStatusChange>()
                .ForMember(d => d.Status, o => o.UseValue(JobOfferStatus.Confirmed))
                .ForMember(d => d.AuthorId, o => o.Ignore())
                .ForMember(d => d.AuthorRole, o => o.Ignore())
                .ForMember(d => d.ContactInformation, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreateDateTime, o => o.Ignore());

            Mapper.CreateMap<JobOfferAcceptDto, JobOfferStatusChange>()
                .ForMember(d => d.Status, o => o.UseValue(JobOfferStatus.Accepted))
                .ForMember(d => d.AuthorId, o => o.Ignore())
                .ForMember(d => d.AuthorRole, o => o.Ignore())
                .ForMember(d => d.ContactInformation, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreateDateTime, o => o.Ignore());
        }

        private static void ToViewModel()
        {
            Mapper.CreateMap<ContactInformation, ContactInformationViewModel>()
                .ForMember(d => d.JobOfferId, o => o.MapFrom(s => s.JobOfferStatusChange.JobOfferId));

            Mapper.CreateMap<JobOfferStatusChange, JobOfferStatusChangeViewModel>()
                .ForMember(d => d.AuthorName, o => o.Ignore());

            Mapper.CreateMap<UserAccount, ProfilePublicViewModel>()
                .ForMember(d => d.ProfileRole, o => o.MapFrom(s => s.Role))
                .ForMember(d => d.Developer, o => o.NullSubstitute(new ProfilePublicDeveloperViewModel()))
                .ForMember(d => d.Recruiter, o => o.NullSubstitute(new ProfilePublicRecruiterViewModel()))
                .ForMember(d => d.CurrentUserRole, o => o.Ignore())
                .ForMember(d => d.CurrentUserProfileIsActive, o => o.Ignore());


            Mapper.CreateMap<Developer, ProfilePublicDeveloperViewModel>()
                .ForMember(d => d.SkillsViewModels, o => o.ResolveUsing<DeveloperToListOfDeveloperSkillsViewModel>());

            Mapper.CreateMap<Developer, ProfilePrivateDeveloperViewModel>()
                .ForMember(d => d.Skills, o => o.ResolveUsing<DeveloperToListOfDeveloperSkillsViewModel>())
                .AfterMap((s, d) => d.Skills.Add(new DeveloperSkillViewModel()));

            Mapper.CreateMap<Recruiter, ProfilePrivateRecruiterViewModel>();

            Mapper.CreateMap<Recruiter, ProfilePublicRecruiterViewModel>();

            Mapper.CreateMap<UserAccount, ProfilePrivateViewModel>()
                .ForMember(d => d.Recruiter, o => o.NullSubstitute(new ProfilePrivateRecruiterViewModel()))
                .ForMember(d => d.Developer, o => o.NullSubstitute(new ProfilePrivateDeveloperViewModel()))
                .ForMember(d => d.LoggedInUserRole, o => o.Ignore())
                .ForMember(d => d.FormActionLinkForUserRole, o => o.Ignore())
                .ForMember(d => d.FormActionUpdateDeveloper, o => o.Ignore())
                .ForMember(d => d.FormActionUpdateRecruiter, o => o.Ignore());


            Mapper.CreateMap<Developer, DeveloperHeadlineViewModel>();

            Mapper.CreateMap<Skill, SkillViewModel>();

            Mapper.CreateMap<DeveloperSkill, DeveloperSkillViewModel>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Skill.Name))
                .ForMember(d => d.Level, o => o.MapFrom(s => s.Level))
                .ForMember(d => d.SkillId, o => o.MapFrom(s => s.SkillId));

            Mapper.CreateMap<JobOffer, JobOfferHeadlineViewModel>()
                .ForMember(d => d.DeveloperDisplayName, o => o.MapFrom(s => s.Developer.DisplayName))
                .ForMember(
                    d => d.Status,
                    o => o.MapFrom(s => s.Statuses.OrderByDescending(status => status.CreateDateTime).First().Status))
                .ForMember(d => d.MessagesCount, o => o.Ignore());


            Mapper.CreateMap<JobOffer, JobOfferDetailViewModel>()
                .ForMember(d => d.DeveloperDisplayName, o => o.MapFrom(s => s.Developer.DisplayName))
                .ForMember(d => d.JobOfferStatusChangeViewModels, o => o.MapFrom(s => s.Statuses))
                .ForMember(
                    d => d.Status,
                    o => o.MapFrom(s => s.Statuses.OrderByDescending(status => status.CreateDateTime).First().Status));

            Mapper.CreateMap<JobOfferComment, JobOfferCommentViewModel>()
                .ForMember(d => d.AuthorDisplayName,
                    o => o.ResolveUsing<JobOfferCommentAuthorDisplayNameResolver>());
        }
    }
}