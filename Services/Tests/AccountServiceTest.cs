namespace DreamJob.Services.Tests
{
    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class AccountServiceTest
    {
        private dynamic sut;

        private dynamic mockUserRepository;
        private dynamic mockSession;

        [TestFixtureSetUp]
        public void Once()
        {
        }

        [SetUp]
        public void OncePerTest()
        {
            this.mockUserRepository = new Mock<IUserRepository>();
            this.mockSession = new Mock<ISession>();
            this.sut = new AccountService(this.mockUserRepository.Object, this.mockSession.Object);
        }


        [Test]
        public void T001()
        {
            // arrange
            object candidateRegistrationData = null;

            // arrange-mock

            // act
            this.sut.Register(candidateRegistrationData);

            // assert

            // assert-mock
            this.mockUserRepository.Verify(x => x.Insert(It.IsAny<object>), Times.Once);
            this.mockUserRepository.Save();
        }


        [Test]
        public void T002()
        {
            // arrange
            object recruiterRegistrationData = null;

            // arrange-mock

            // act
            this.sut.Register(recruiterRegistrationData);

            // assert

            // assert-mock
            this.mockUserRepository.Verify(x => x.Insert(It.IsAny<object>()), Times.Once);
            this.mockUserRepository.Save();
        }


        [Test]
        public void T003()
        {
            // arrange
            object recruiterLoginData = null;

            // arrange-mock

            // act
            this.sut.Login(recruiterLoginData);

            // assert

            // assert-mock
            this.mockUserRepository.Find();
            this.mockSession.SetLoggedUser();
        }

        [Test]
        public void T004()
        {
            // arrange

            // arrange-mock

            // act
            this.sut.Login(candidateLoginData);

            // assert

            // assert-mock
            this.mockUserRepository.Find();
            this.mockSession.SetLoggedUser();
        }

        [Test]
        public void T005()
        {
            // arrange

            // arrange-mock

            // act
            this.sut.Logout();

            // assert

            // assert-mock
            this.mockSession.SetLoggedUser(null);
        }
    }

    public interface IUserRepository
    {
    }

    internal interface IAccountService
    {
        void Register(object candidateRegistrationData);
    }

    public class AccountService : IAccountService
    {
    }
}
 