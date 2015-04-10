using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DreamJob.Controllers;
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
        private IJobOfferService jobOfferService;


        public TestService(IAccountService accountService,
            IProfileService profileService,
            ApplicationDatabase database,
            ICommentService commentService,
            IJobOfferService jobOfferService)
        {
            this.accountService = accountService;
            this.profileService = profileService;
            this.database = database;
            this.commentService = commentService;
            this.random = new Random();
            this.jobOfferService = jobOfferService;
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

            TestAccountService.CurrectLoggedUserId = profile.Id;
            TestAccountService.CurrentLoggedUserRole = ApplicationUserRole.Developer;
            this.profileService.UpdateDeveloperProfile(updateProfile);
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
                    Level = this.random.Next(1, 10),
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

            TestAccountService.CurrentLoggedUserRole = ApplicationUserRole.Recruiter;
            TestAccountService.CurrectLoggedUserId = profile.Id;
            this.profileService.UpdateRecruiterProfile(updateProfile);
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
                this.SetOfferRandomAuthorId(offer);
                this.commentService.Add(comment);
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
                this.SetOfferRandomAuthorId(offer);
                this.commentService.Add(comment);
            }
        }

        private void SetOfferRandomAuthorId(JobOffer offer)
        {
            if (this.random.Next(1, 2) % 2 == 0)
            {
                TestAccountService.CurrectLoggedUserId = offer.DeveloperId;
                TestAccountService.CurrentLoggedUserRole = ApplicationUserRole.Developer;
            }
            else
            {
                TestAccountService.CurrectLoggedUserId = offer.RecruiterId;
                TestAccountService.CurrentLoggedUserRole = ApplicationUserRole.Recruiter;
            }
        }

        private CommentAddDto GetRandomComment(long id)
        {
            var result = new CommentAddDto
            {
                JobOfferId = id,
                Text = Faker.TextFaker.Sentences(this.random.Next(1, 10))
            };
            return result;
        }

        public void CreateOffers(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.CreateOffer();
            }
        }

        private void CreateOffer()
        {
            var allDevelopers = this.database.Developers.ToList();
            var allRecruiters = this.database.Recruiters.ToList();

            var recruiter = allRecruiters.ElementAt(this.random.Next(allRecruiters.Count - 1));
            var developer = allDevelopers.ElementAt(this.random.Next(allDevelopers.Count - 1));
            var dto = new JobOfferSendDto
            {
                CompanyName = Faker.CompanyFaker.Name(),
                DeveloperId = developer.Id,
                JobOfferText = Faker.TextFaker.Sentence(),
                OfferMatchesProfile = true,
                Position = "developer",
                ProfileWasReadBeforeSending = true,
                Requirements = Faker.TextFaker.Sentence(),
                Salary = developer.Salary
            };



            TestAccountService.CurrectLoggedUserId = recruiter.UserAccountId;
            TestAccountService.CurrentLoggedUserRole = ApplicationUserRole.Recruiter;

            this.jobOfferService.Add(dto);
        }

        public void CreateOfferResponses(int count, int offersCount)
        {
            throw new System.NotImplementedException();
        }

        public void HijacIoc()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TestAccountService>().As<IAccountService>().SingleInstance();
            builder.Update(ApplicationIocContainer.Container);
        }

        public void Restore()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WebSecurityAccountService>().As<IAccountService>();
            builder.Update(ApplicationIocContainer.Container);
        }

        public TestIndexViewModel GetViewModel()
        {
            var isHijacked = ApplicationIocContainer.Container.Resolve<IAccountService>() is TestAccountService;
            var result = new TestIndexViewModel(isHijacked);
            return result;
        }
    }

    internal class TestAccountService : IAccountService
    {
        private WebSecurityAccountService trueAccountService;

        public TestAccountService()
        {
            this.trueAccountService = new WebSecurityAccountService();
        }

        public void Logout()
        {
            //empty on purpose
        }

        public static bool LoginResult { get; set; }
        public bool Login(ProfileLoginDto dto)
        {
            return LoginResult;
        }

        public void RegisterDeveloper(ProfileRegisterDto dto)
        {
            this.trueAccountService.RegisterDeveloper(dto);
        }

        public void RegisterRecruiter(ProfileRegisterDto dto)
        {
            this.trueAccountService.RegisterRecruiter(dto);
        }

        public long GetCurrentLoggedUserId()
        {
            return CurrectLoggedUserId;
        }

        public static long CurrectLoggedUserId { get; set; }

        public ApplicationUserRole GetCurrentLoggedUserRole()
        {
            return CurrentLoggedUserRole;
        }

        public static ApplicationUserRole CurrentLoggedUserRole { get; set; }
    }
}