using AutoMapper.Internal;

namespace DreamJob.Services
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using AutoMapper;

    using DreamJob.Dtos;
    using DreamJob.Infrastructure;
    using DreamJob.Models;
    using DreamJob.ViewModels;

    public class ProfileService : IProfileService
    {
        private readonly ApplicationDatabase applicationDatabase;
        private readonly IAccountService authentication;

        public ProfileService(ApplicationDatabase applicationDatabase, IAccountService authentication)
        {
            this.applicationDatabase = applicationDatabase;
            this.authentication = authentication;
        }

        public void RegisterDeveloper(ProfileRegisterDto dto)
        {
            var model = Mapper.Map<ProfileRegisterDto, UserAccount>(dto);
            model.PasswordHash = dto.Password;
            model.CreateDateTime = DateTime.Now;
            this.applicationDatabase.Profiles.Add(model);
            this.applicationDatabase.SaveChanges();
        }

        public ProfilePublicViewModel GetPublicDataForUserId(long id)
        {
            var model =
                this.applicationDatabase.Profiles
                    .Include(p => p.Developer)
                    .Include(p => p.Recruiter)
                    .Include(p => p.Developer)
                    .Include(p => p.Developer.Skills)
                    .Include(p => p.Developer.Skills.Select(dd => dd.Skill))
                    .First(d => d.Id == id);
            var viewmodel = Mapper.Map<UserAccount, ProfilePublicViewModel>(model);

            var currentLoggedUserRole = this.authentication.GetCurrentLoggedUserRole();
            var currentLoggedUserId = this.authentication.GetCurrentLoggedUserId();

            viewmodel.CurrentUserRole = currentLoggedUserRole;

            var currentLoggedInUserModel =
                this.applicationDatabase.Profiles.Include(r => r.Recruiter)
                    .Include(r => r.Developer)
                    .First(p => p.Id == currentLoggedUserId);
            viewmodel.CurrentUserProfileIsActive = currentLoggedInUserModel.Role == ApplicationUserRole.Developer
                                                       ? currentLoggedInUserModel.Developer.IsActive
                                                       : currentLoggedInUserModel.Recruiter.IsActive;
            return viewmodel;
        }

        public ProfilePublicViewModel GetPublicDataForLoggedUser()
        {
            var userId = this.authentication.GetCurrentLoggedUserId();
            var model =
                this.applicationDatabase.Profiles.Include(p => p.Developer)
                    .Include(p => p.Recruiter)
                    .Include(p => p.Developer)
                    .Include(p => p.Developer.Skills)
                    .Include(p => p.Developer.Skills.Select(dd => dd.Skill))
                    .First(d => d.Id == userId);
            var viewmodel = Mapper.Map<UserAccount, ProfilePublicViewModel>(model);
            return viewmodel;
        }

        public ProfilePrivateViewModel GetPrivateDataForLoggedUser()
        {
            var userId = this.authentication.GetCurrentLoggedUserId();
            var model =
                this.applicationDatabase.Profiles
                    .Include(p => p.Developer)
                    .Include(p => p.Recruiter)
                    .Include(p => p.Developer)
                    .Include(p => p.Developer.Skills)
                    .Include(p => p.Developer.Skills.Select(dd => dd.Skill))
                    .First(d => d.Id == userId);
            var viewmodel = Mapper.Map<UserAccount, ProfilePrivateViewModel>(model);
            viewmodel.LoggedInUserRole = this.authentication.GetCurrentLoggedUserRole();
            return viewmodel;
        }

        public void UpdateRecruiterProfile(ProfilePrivateRecruiterDto dto)
        {
            var currentUserid = this.authentication.GetCurrentLoggedUserId();
            this.UpdateRecruiterProfileById(dto, currentUserid);
        }

        private void UpdateRecruiterProfileById(ProfilePrivateRecruiterDto dto, long currentUserid)
        {
            var model =
                this.applicationDatabase.Profiles
                    .Include(p => p.Recruiter)
                    .First(d => d.Id == currentUserid);

            this.UpdateRecruiterProfile(dto, model, currentUserid);
            this.applicationDatabase.SaveChanges();
        }


        private void UpdateRecruiterProfile(ProfilePrivateRecruiterDto dto, UserAccount model, long currentUserid)
        {
            if (model.Recruiter == null)
            {
                model.Recruiter = new Recruiter();
                model.Recruiter.CreateDateTime = DateTime.Now;
                model.Recruiter.UserAccountId = currentUserid;
            }

            model.Recruiter.FirstName = dto.FirstName;
            model.Recruiter.LastName = dto.LastName;
            model.Recruiter.Email = dto.Email;
            model.Recruiter.Employer = dto.Employer;
            model.Recruiter.IsActive = dto.IsActive;
        }

        public void UpdateDeveloperProfile(ProfilePrivateDeveloperEditDto dto)
        {
            var currentUserid = this.authentication.GetCurrentLoggedUserId();

            var model =
                this.applicationDatabase.Profiles.Include(p => p.Developer)
                    .Include(p => p.Developer)
                    .Include(p => p.Developer.Skills)
                    .Include(p => p.Developer.Skills.Select(dd => dd.Skill))
                    .First(d => d.Id == currentUserid);
            this.UpdateDeveloperProfile(dto, model, currentUserid);
            this.applicationDatabase.SaveChanges();
        }

        private void UpdateDeveloperProfile(ProfilePrivateDeveloperEditDto dto, UserAccount model, long currentUserid)
        {
            if (model.Developer == null)
            {
                model.Developer = new Developer();
                model.Developer.CreateDateTime = DateTime.Now;
                model.Developer.UserAccountId = model.Id;
            }

            model.Developer.DisplayName = dto.DisplayName;
            model.Developer.AboutMe = dto.AboutMe;
            model.Developer.LookingFor = dto.LookingFor;
            model.Developer.Salary = dto.Salary;
            model.Developer.IsActive = dto.IsActive;
            model.Developer.CurrentWorkingLocation = dto.CurrentWorkingLocation;
            model.Developer.WillingToRelocateToDifferentCity = dto.WillingToRelocateToDifferentCity;
            model.Developer.WillingToRelocateToDifferentCountry = dto.WillingToRelocateToDifferentCountry;

            dto.Skills.Where(skillDto => skillDto.SkillId > 0)
                .ToList()
                .ForEach(
                    skillDto =>
                    model.Developer.Skills.First(developerSkill => developerSkill.SkillId == skillDto.SkillId).Level =
                    skillDto.Level);

            var newSkills =
                dto.Skills.Where(
                    skill => skill.SkillId <1 && string.IsNullOrEmpty(skill.Name) == false && skill.Level > 0);

            newSkills.ToList().ForEach(newSkill =>
            {
                var skillInDb = this.applicationDatabase.Skills.FirstOrDefault(dbSkill => dbSkill.Name == newSkill.Name);

                if (skillInDb == null)
                {
                    skillInDb = new Skill(newSkill.Name);
                    skillInDb.CreateDateTime = DateTime.Now;
                    this.applicationDatabase.Skills.Add(skillInDb);
                }

                var developerSkill = new DeveloperSkill(skillInDb.Id, currentUserid, newSkill.Level);
                developerSkill.CreateDateTime = DateTime.Now;
                model.Developer.Skills.Add(developerSkill);
            });
        }

        public void RemoveSkillFromProfile(long skillId)
        {
            var currentUserid = this.authentication.GetCurrentLoggedUserId();
            var user = this.applicationDatabase.Developers.Include(d => d.Skills).First(d => d.Id == currentUserid);
            var developerSkill = user.Skills.First(s => s.SkillId == skillId);
            this.applicationDatabase.DeveloperSkills.Remove(developerSkill);
            this.applicationDatabase.SaveChanges();
        }

        public HomeIndexViewModel GetDevelopersHeadlines()
        {
            var allDevelopers = this.applicationDatabase
                .Developers
                .Where(d => d.IsActive)
                .Include(d => d.Skills)
                .OrderByDescending(d => d.CreateDateTime)
                .ToList();
            var headlines = Mapper.Map<List<Developer>, List<DeveloperHeadlineViewModel>>(allDevelopers);
            var viewModel = new HomeIndexViewModel(headlines);
            return viewModel;
        }

        public SearchResultViewModel GetDevelopersHeadlinesWithSkill(SearchSkillDto dto)
        {
            var requestedSkills = dto.Skill.ToLower().Split(new[] { " ", ",", ";", }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var skills =
                this.applicationDatabase.Skills.Where(
                    skill => requestedSkills.Any(rs => skill.Name.ToLower().Contains(rs))).ToList();

            var skillsIds = skills.Select(s => s.Id).ToList();

            var activeDevelopers = this.applicationDatabase
                .DeveloperSkills
                .Include(ds => ds.Developer)
                .Where(d => d.Developer.IsActive);

            var developerSkills = activeDevelopers
                .Where(ds => skillsIds.Contains(ds.SkillId));
            var developersWithSkill =
                developerSkills
                //.Distinct()
                    .Select(ds => ds.Developer)
                    .Include(d => d.Skills)
                    .ToList();

            var skillMatchedFount = Mapper.Map<List<Skill>, List<SkillViewModel>>(skills);
            var headlines = Mapper.Map<List<Developer>, List<DeveloperHeadlineViewModel>>(developersWithSkill);
            return new SearchResultViewModel(headlines, skillMatchedFount, requestedSkills);
        }

        public SearchResultViewModel GetDevelopersHeadlinesWithSalaryInRange(SearchSalaryDto dto)
        {
            var developersHeadlines =
                this.applicationDatabase
                .Developers
                .Include(d => d.Skills)
                .Where(d => d.IsActive)
                .Where(d => d.Salary < dto.Maximum)
                .Where(d => d.Salary > dto.Minimum)
                .ToList();
            var headlines = Mapper.Map<List<Developer>, List<DeveloperHeadlineViewModel>>(developersHeadlines);
            return new SearchResultViewModel(headlines);
        }
    }
}