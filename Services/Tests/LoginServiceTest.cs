namespace DreamJob.Services.Tests
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Services.Interfaces;
    using DreamJob.Services.Interfaces.Model;

    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class LoginServiceTest
    {
        private ILoginService sut;

        private Mock<IUserRepository> mockUserRepository;
        private Mock<ISession> mockSession;

        [TestFixtureSetUp]
        public void Once()
        {
        }

        [SetUp]
        public void OncePerTest()
        {
            mockUserRepository = new Mock<IUserRepository>();
            mockSession = new Mock<ISession>();

            this.sut = new LoginService(this.mockUserRepository.Object);
        }

        [Test]
        public void T001()
        {
            // arrange
            UserLoginData userLoginDataCandidate = UserLoginDataModelFactory.CreateCandidate();
            User userToLoginCandidate = UserModelFactory.CreateCandidate();

            // arrange-mock
            this.mockUserRepository.Setup(x => x.FindUserByLoginAndHash(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(userToLoginCandidate);

            // act
            this.sut.Login(userLoginDataCandidate);

            // assert

            // assert-mock
            this.mockUserRepository.Verify(
                x =>
                x.FindUserByLoginAndHash(
                    It.Is<string>(v => v == userLoginDataCandidate.Login),
                    It.Is<string>(v => v == userLoginDataCandidate.HashedPassword)),
                    Times.Once());

        }

        [Test]
        public void T002()
        {
            // arrange
            UserLoginData userLoginDataRecruiter = UserLoginDataModelFactory.CreateRecruiter();
            User userToLoginRecruiter = UserModelFactory.CreateRecruiter();

            // arrange-mock
            this.mockUserRepository.Setup(x => x.FindUserByLoginAndHash(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(userToLoginRecruiter);

            // act
            this.sut.Login(userLoginDataRecruiter);

            // assert

            // assert-mock
            this.mockUserRepository.Verify(
                x =>
                x.FindUserByLoginAndHash(
                    It.Is<string>(v => v == userLoginDataRecruiter.Login),
                    It.Is<string>(v => v == userLoginDataRecruiter.HashedPassword)),
                    Times.Once());
            this.mockSession.Verify(x => x.SetLoggedUser(It.IsAny<Recruiter>()), Times.Once());
        }

        [Test]
        public void T003()
        {
            // arrange

            // arrange-mock

            // act
            this.sut.Logout();

            // assert

            // assert-mock
            this.mockSession.Verify(x => x.SetLoggedUser(It.IsAny<object>()), Times.Once);
        }
    }

    public class UserModelFactory
    {
        public static User CreateCandidate()
        {
            throw new System.NotImplementedException();
        }

        internal static User CreateRecruiter()
        {
            throw new System.NotImplementedException();
        }
    }

    public class UserLoginDataModelFactory
    {
        public static UserLoginData CreateCandidate()
        {
            throw new System.NotImplementedException();
        }

        internal static UserLoginData CreateRecruiter()
        {
            throw new System.NotImplementedException();
        }
    }
}