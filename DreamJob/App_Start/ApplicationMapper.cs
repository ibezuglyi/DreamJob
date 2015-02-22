namespace DreamJob
{
    using AutoMapper;

    using DreamJob.Dtos;
    using DreamJob.Infrastructure;
    using DreamJob.Models;
    using DreamJob.Services;
    using DreamJob.ViewModels;

    public static class ApplicationMapper
    {
        public static void Initialize()
        {
            Mapper.CreateMap<ProfileRegisterDto, UserAccount>();
            Mapper.CreateMap<UserAccount, ApplicationUser>();
            Mapper.CreateMap<UserAccount, ProfilePublicViewModel>()
                .ForMember(d => d.ProfileRole, o => o.MapFrom(s => s.Role))
                .ForMember(d => d.Developer, o => o.NullSubstitute(new ProfilePublicDeveloperViewModel()))
                .ForMember(d => d.Recruiter, o => o.NullSubstitute(new ProfilePublicRecruiterViewModel()));

            Mapper.CreateMap<Developer, ProfilePublicDeveloperViewModel>()
                .ForMember(d => d.SkillsViewModels, o => o.MapFrom(s => s.Skills));

            Mapper.CreateMap<Developer, ProfilePrivateDeveloperViewModel>()
                .ForMember(d => d.Skills, o => o.MapFrom(s => s.Skills))
                .AfterMap((s, d) => d.Skills.Add(new DeveloperSkillViewModel()));

            Mapper.CreateMap<Recruiter, ProfilePrivateRecruiterViewModel>();

            Mapper.CreateMap<Recruiter, ProfilePublicRecruiterViewModel>();

            Mapper.CreateMap<UserAccount, ProfilePrivateViewModel>()
                .ForMember(d => d.Recruiter, o => o.NullSubstitute(new ProfilePrivateRecruiterViewModel()))
                .ForMember(d => d.Developer, o => o.NullSubstitute(new ProfilePrivateDeveloperViewModel()));

            Mapper.CreateMap<Developer, DeveloperHeadlineViewModel>();

            Mapper.CreateMap<Skill, SkillViewModel>();

            Mapper.CreateMap<DeveloperSkill, DeveloperSkillViewModel>()
                .ConstructUsing(
                    ds =>
                    new DeveloperSkillViewModel(
                        new DeveloperSkillDto { Level = ds.Level, Name = ds.Skill.Name, SkillId = ds.SkillId }));




            Mapper.CreateMap<JobOfferSendDto, JobOffer>();
            Mapper.CreateMap<JobOffer, JobOfferHeadlineViewModel>()
                .ForMember(d => d.DeveloperDisplayName, o => o.MapFrom(s => s.Developer.DisplayName));

            Mapper.CreateMap<JobOffer, JobOfferDetailViewModel>()
                .ForMember(d => d.DeveloperDisplayName, o => o.MapFrom(s => s.Developer.DisplayName));

            Mapper.CreateMap<CommentAddDto, JobOfferComment>();
            Mapper.CreateMap<JobOfferComment, JobOfferCommentViewModel>();


            Mapper.CreateMap<JobOfferRejectDto, JobOfferReject>();
            Mapper.CreateMap<JobOfferCancelDto, JobOfferCancel>();
            Mapper.CreateMap<JobOfferConfirmDto, JobOfferConfirm>();
            Mapper.CreateMap<JobOfferAcceptDto, JobOfferAccept>();
        }
    }
}