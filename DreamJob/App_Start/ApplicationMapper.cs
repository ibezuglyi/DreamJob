using System.Web;
using System.Web.Mvc;

namespace DreamJob
{
    using System.Linq;
    using ValueResolvers;

    using AutoMapper;

    using Dtos;
    using Infrastructure;
    using Models;
    using ViewModels;
    using ExtensionMethods;

    public static class ApplicationMapper
    {
        public static void Initialize()
        {
            ToViewModel();
            ToEntity();
            ToDto();
            Mapper.CreateMap<UserAccount, ApplicationUser>();
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
            Mapper.CreateMap<ContactInformationDto, ContactInformation>();

            Mapper.CreateMap<ProfileRegisterDto, UserAccount>();

            Mapper.CreateMap<JobOfferSendDto, JobOffer>();

            Mapper.CreateMap<CommentAddDto, JobOfferComment>();

            Mapper.CreateMap<JobOfferRejectDto, JobOfferStatusChange>()
                .ForMember(d => d.Status, o => o.UseValue(JobOfferStatus.Rejected));

            Mapper.CreateMap<JobOfferCancelDto, JobOfferStatusChange>()
                .ForMember(d => d.Status, o => o.UseValue(JobOfferStatus.Canceled));

            Mapper.CreateMap<JobOfferConfirmDto, JobOfferStatusChange>()
                .ForMember(d => d.Status, o => o.UseValue(JobOfferStatus.Confirmed));

            Mapper.CreateMap<JobOfferAcceptDto, JobOfferStatusChange>()
                .ForMember(d => d.Status, o => o.UseValue(JobOfferStatus.Accepted));
        }

        private static void ToViewModel()
        {
            Mapper.CreateMap<ContactInformation, ContactInformationViewModel>()
                .ForMember(d => d.JobOfferId, o => o.MapFrom(s => s.JobOfferStatusChange.JobOfferId));

            Mapper.CreateMap<JobOfferStatusChange, JobOfferStatusChangeViewModel>();

            Mapper.CreateMap<UserAccount, ProfilePublicViewModel>()
                .ForMember(d => d.ProfileRole, o => o.MapFrom(s => s.Role))
                .ForMember(d => d.Developer, o => o.NullSubstitute(new ProfilePublicDeveloperViewModel()))
                .ForMember(d => d.Recruiter, o => o.NullSubstitute(new ProfilePublicRecruiterViewModel()));

            Mapper.CreateMap<Developer, ProfilePublicDeveloperViewModel>()
                .ForMember(d => d.SkillsViewModels, o => o.MapFrom(s => s.Skills.OrderByDescending(r => r.Level)));

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

            Mapper.CreateMap<JobOffer, JobOfferHeadlineViewModel>()
                .ForMember(d => d.DeveloperDisplayName, o => o.MapFrom(s => s.Developer.DisplayName))
                .ForMember(
                    d => d.Status,
                    o => o.MapFrom(s => s.Statuses.OrderByDescending(status => status.CreateDateTime).First().Status));

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