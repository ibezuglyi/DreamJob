namespace DreamJob.Services.Tests
{
    using DreamJob.Interfaces;
    using DreamJob.Services.Login;

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
            object recruiterLoginData = null;

            // arrange-mock

            // act
            this.sut.Login(recruiterLoginData);

            // assert

            // assert-mock
            this.mockUserRepository.Verify(x => x.Find(recruiterLoginData), Times.Once);
            this.mockSession.Verify(x => x.SetLoggedUser(It.IsAny<object>()), Times.Once());
        }

        [Test]
        public void T002()
        {
            // arrange
            object candidateLoginData = null;

            // arrange-mock

            // act
            this.sut.Login(candidateLoginData);

            // assert

            // assert-mock
            this.mockUserRepository.Verify(x => x.Find(candidateLoginData), Times.Once);
            this.mockSession.Verify(x => x.SetLoggedUser(It.IsAny<object>()), Times.Once());
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
}