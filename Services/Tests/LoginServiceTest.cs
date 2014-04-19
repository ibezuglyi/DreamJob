namespace DreamJob.Services.Tests
{
    using System.Text;

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

            this.sut = new LoginService(this.mockUserRepository.Object, this.mockSession.Object);
        }

        [Test]
        public void T001()
        {
            // arrange
            UserLoginData userLoginDataCandidate = UserLoginDataModelFactory.CreateCandidate();
            UserPublicData userPublicData = UserPublicDateModelFactory.CreateCandidate();

            // arrange-mock
            this.mockUserRepository.Setup(x => x.GetUserPublicDataByLoginAndHash(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(userPublicData);

            this.mockSession.Setup(x => x.SetLoggedUser(It.IsAny<UserPublicData>())).Verifiable();

            // act
            this.sut.Login(userLoginDataCandidate);

            // assert
            // assert-mock
            this.mockUserRepository.Verify(
                x =>
                x.GetUserPublicDataByLoginAndHash(
                    It.Is<string>(v => v == userLoginDataCandidate.Login),
                    It.Is<string>(v => v == userLoginDataCandidate.HashedPassword)),
                    Times.Once());

            this.mockSession.Verify(x => x.SetLoggedUser(It.IsAny<UserPublicData>()), Times.Once);
        }

        [Test]
        public void T002()
        {
            // arrange
            UserLoginData userLoginDataRecruiter = UserLoginDataModelFactory.CreateRecruiter();
            UserPublicData userPublicData = UserPublicDateModelFactory.CreateCandidate();

            // arrange-mock
            this.mockUserRepository.Setup(x => x.GetUserPublicDataByLoginAndHash(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(userPublicData);
            this.mockSession.Setup(x => x.SetLoggedUser(It.IsAny<UserPublicData>())).Verifiable();

            // act
            this.sut.Login(userLoginDataRecruiter);

            // assert

            // assert-mock
            this.mockUserRepository.Verify(
                x =>
                x.GetUserPublicDataByLoginAndHash(
                    It.Is<string>(v => v == userLoginDataRecruiter.Login),
                    It.Is<string>(v => v == userLoginDataRecruiter.HashedPassword)),
                    Times.Once());
            this.mockSession.Verify(x => x.SetLoggedUser(It.IsAny<UserPublicData>()), Times.Once());
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
            this.mockSession.Verify(x => x.LogOff(), Times.Once);
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

    public class UserPublicDateModelFactory
    {
        public static UserPublicData CreateCandidate()
        {
            var result = new UserPublicData
                             {
                                 AccountType = UserAccountType.Candidate,
                                 Id = 2233,
                                 Login = "test-candidate-user-name"
                             };

            return result;
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