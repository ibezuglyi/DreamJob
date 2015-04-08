using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Autofac;
using DreamJob.Dtos;
using DreamJob.Infrastructure;
using DreamJob.Models;
using DreamJob.ViewModels;

namespace DreamJob.Services
{
    class TestService : ITestService
    {
        private readonly IAccountService accountService;
        private readonly IProfileService profileService;
        private readonly ApplicationDatabase database;
        private readonly Random random;
        private readonly ICommentService commentService;

        public TestService(
            IAccountService accountService,
            IProfileService profileService,
            ApplicationDatabase database,
            ICommentService commentService)
        {
            this.accountService = accountService;
            this.profileService = profileService;
            this.database = database;
            this.commentService = commentService;
            this.random = new Random();
        }

        public void CreateNewDevelopers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.CreateNewDeveloper();
            }
        }

        private void CreateNewDeveloper()
        {
            string email = this.GetWord(10) + Faker.InternetFaker.Email();
            var dto = new ProfileRegisterDto
            {
                ConfirmPassword = "1234",
                Email = email,
                Password = "1234",
                Role = ApplicationUserRole.Developer
            };

            this.accountService.RegisterDeveloper(dto);
            var profile = this.database.Profiles.First(p => p.Email == email);

            var updateProfile = new ProfilePrivateDeveloperEditDto
            {
                AboutMe = this.GetSentence(100),
                DisplayName = this.GetWord(15),
                IsActive = true,
                LookingFor = this.GetSentence(100),
                Salary = this.random.Next(1000, 20000),
                Skills = this.GetSkills(2, 1),
                Action = string.Empty
            };

            this.profileService.UpdateDeveloperProfile(updateProfile, profile.Id);
        }

        private List<DeveloperSkillDto> GetSkills(int oldSkills, int newSkills)
        {
            var allList = this.database.Skills.ToList();
            var list = new List<DeveloperSkillDto>();

            if (allList.Any())
            {
                for (int i = 0; i < oldSkills; i++)
                {
                    var oldSkill = allList.ElementAt(this.random.Next(allList.Count - 1));
                    var dto = new DeveloperSkillDto
                    {
                        Level = this.random.Next(100),
                        Name = oldSkill.Name
                    };
                    list.Add(dto);
                }
            }

            for (int i = 0; i < newSkills; i++)
            {
                var dto = new DeveloperSkillDto
                {
                    Level = this.random.Next(100),
                    Name = this.GetWord(10),
                    SkillId = 0
                };
                list.Add(dto);
            }

            return list;
        }

        private string GetSentence(int wordsCount)
        {
            var sb = new StringBuilder();
            for (int index = 0; index < wordsCount; index++)
            {
                sb.AppendFormat("{0} ", this.GetWord(this.random.Next(3, 15)));
            }
            sb.Append(".");
            return sb.ToString();
        }

        private string GetWord(int lenght)
        {
            var letters = "qwertyuioplkjhgfdsazxcvbnm";
            var sb = new StringBuilder();

            for (int index = 0; index < lenght; index++)
            {
                sb.Append(letters[this.random.Next(letters.Length - 1)]);
            }
            return sb.ToString();
        }

        public void CreateNewRecruites(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.CreateNewRecruiter();
            }
        }

        private void CreateNewRecruiter()
        {
            string email = this.GetWord(10) + Faker.InternetFaker.Email();
            var dto = new ProfileRegisterDto
            {
                ConfirmPassword = "1234",
                Email = email,
                Password = "1234",
                Role = ApplicationUserRole.Recruiter
            };

            this.accountService.RegisterRecruiter(dto);
            var profile = this.database.Profiles.First(p => p.Email == email);

            var updateProfile = new ProfilePrivateRecruiterDto
            {
                Email = email,
                Employer = Faker.InternetFaker.Domain(),
                FirstName = Faker.NameFaker.FirstName(),
                IsActive = true,
                LastName = Faker.NameFaker.LastName()
            };

            this.profileService.UpdateRecruiterProfile(updateProfile, profile.Id);
        }

        public void CreateComments(int commentCounts, int offerCount)
        {
            if (offerCount == 1)
            {
                this.CreateCommentsForOneOffer(commentCounts);
            }
            if (offerCount == 0)
            {
                this.CreateCommentsForRandomOffers(commentCounts);
            }
        }

        private void CreateCommentsForRandomOffers(int commentCounts)
        {
            var jobOffers = this.database.JobOffers.ToList();
            var offerCount = jobOffers.Count();
            for (int i = 0; i < commentCounts; i++)
            {
                var offer = jobOffers.ElementAt(this.random.Next(0, offerCount));
                var comment = this.GetRandomComment(offer.Id);
                var authorId = this.GetOfferRandomAuthorId(offer);
                this.commentService.AddByAuthorId(comment, authorId);
            }
        }

        private void CreateCommentsForOneOffer(int commentCounts)
        {
            var jobOffers = this.database.JobOffers.ToList();
            var offerCount = jobOffers.Count();
            var index = this.random.Next(0, offerCount);
            var offer = jobOffers.ElementAt(index);
            for (int i = 0; i < commentCounts; i++)
            {
                var comment = this.GetRandomComment(offer.Id);
                var authorId = this.GetOfferRandomAuthorId(offer);
                this.commentService.AddByAuthorId(comment, authorId);
            }
        }

        private long GetOfferRandomAuthorId(JobOffer offer)
        {
            if (this.random.Next(1, 2) % 2 == 0)
            {
                return offer.DeveloperId;
            }
            else
            {
                return offer.RecruiterId;
            }
        }

        private CommentAddDto GetRandomComment(long id)
        {
            var result = new CommentAddDto
            {
                JobOfferId = id,
                Text = Faker.TextFaker.Sentences(this.random.Next(10))
            };
            return result;
        }

        public void CreateOffers(int count)
        {
            throw new System.NotImplementedException();
        }

        public void CreateOfferResponses(int count, int offersCount)
        {
            throw new System.NotImplementedException();
        }


    }
}