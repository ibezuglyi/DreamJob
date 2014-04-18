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


        [Test]
        public void T004_Checking_User_Exists_Must_Ready_Data_From_User_Repository_And_Return_True_If_The_User_Exists()
        {
            // arrange
            var userLogindata = UserLoginDataModelFactory.CreateCandidate();

            // arrange-mock
            this.mockUserRepository.Setup(x => x.UserExists(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // act
            var result = this.sut.UserExists(userLogindata);

            // assert
            Assert.True(result);

            // assert-mock
            this.mockUserRepository.Verify(v => v.UserExists(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void T005_Checking_User_Exists_Must_Ready_Data_From_User_Repository_And_Return_False_If_The_User_Does_Not_Exists()
        {
            // arrange
            var userLogindata = UserLoginDataModelFactory.CreateCandidate();

            // arrange-mock
            this.mockUserRepository.Setup(x => x.UserExists(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            // act
            var result = this.sut.UserExists(userLogindata);

            // assert
            Assert.False(result);

            // assert-mock
            this.mockUserRepository.Verify(v => v.UserExists(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
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
            var result = new UserLoginData
                             {
                                 HashedPassword = "test-hashed-password-goes-here",
                                 Login = "test-candidate-user-name",
                                 RememberMe = true,
                             };

            return result;
        }

        internal static UserLoginData CreateRecruiter()
        {
            throw new System.NotImplementedException();
        }
    }
}