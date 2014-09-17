namespace DreamJob.Ui.Web.Mvc
{
    using System;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Diagnostics;

    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Models.Dto;
    using DreamJob.Ui.Web.Mvc.Services;

    public static class DjAutoMapper
    {
        public static void InitializeAutomapper()
        {
            AutoMapper.Mapper.CreateMap<UserRegistrationDto, Developer>()
                .ForMember(r => r.Edit, o => o.UseValue(DateTime.Now))
                .ForMember(r => r.Add, o => o.UseValue(DateTime.Now));

            AutoMapper.Mapper.CreateMap<UserRegistrationDto, Recruiter>()
                .ForMember(r => r.Edit, o => o.UseValue(DateTime.Now))
                .ForMember(r => r.Add, o => o.UseValue(DateTime.Now));

            AutoMapper.Mapper.CreateMap<User, LoginUserDto>();

            AutoMapper.Mapper.CreateMap<User, UserProfileDto>();
            
                

            AutoMapper.Mapper.CreateMap<JobOffer, JobOfferDetailsDto>()
                .ForMember(d => d.From, o => o.MapFrom(s => RecruiterNameFormat(s.FromRecruiter.FirstName, s.FromRecruiter.LastName)))
                .ForMember(d => d.To, o => o.MapFrom(s => s.ToDeveloper.DisplayName))
                .ForMember(d => d.OfferStatus, o => o.MapFrom(s => s.OfferStatus.ToString()));

            AutoMapper.Mapper.CreateMap<JobOfferComment, JobOfferCommentDto>()
                .ForMember(d => d.Author, o => o.MapFrom(s => s.Author.DisplayName));

            AutoMapper.Mapper.CreateMap<JobOffer, JobOfferDto>()
                .ForMember(d => d.From, o => o.MapFrom(s => RecruiterNameFormat(s.FromRecruiter.FirstName, s.FromRecruiter.LastName)))
                .ForMember(d => d.To, o => o.MapFrom(s => s.ToDeveloper.DisplayName))
                .ForMember(d=>d.FromCompany, o=>o.MapFrom(r=>r.FromRecruiter.Company))
                .ForMember(d=>d.MessagesCount, o=>o.MapFrom(r=>r.JobOfferComments.Count+1))
                .ForMember(d => d.OfferStatus, o => o.MapFrom(s => s.OfferStatus.ToString()));
                


            AutoMapper.Mapper.CreateMap<NewJobOfferDto, JobOffer>()
                .ForMember(
                    destination => destination.ToDeveloperId,
                    option => option.MapFrom(source => source.DeveloperId));

            AutoMapper.Mapper.CreateMap<Developer, DeveloperShortInformationDto>();
            AutoMapper.Mapper.CreateMap<Developer, UserProfileDto>();
            AutoMapper.Mapper.CreateMap<Recruiter, UserProfileDto>();

            AutoMapper.Mapper.CreateMap<Developer, DeveloperProfileDto>();
            AutoMapper.Mapper.CreateMap<Skill, SkillDto>();
            AutoMapper.Mapper.CreateMap<SkillDto, Skill>();
        }

        private static string RecruiterNameFormat(string firstName, string lastName)
        {
            return string.Format("{0} {1}", firstName, lastName);
        }
    }
}