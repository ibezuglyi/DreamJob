namespace DreamJob.Services.Tests
{
    using DreamJob.Domain.Models;
    using DreamJob.Interfaces;
    using DreamJob.Services.Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class RegistrationServiceTest
    {
        private IRegistrationService sut;

        private Mock<IUserRepository> mockUserRepository;
        private Mock<ISession> mockSession;

        [TestFixtureSetUp]
        public void Once()
        {
        }

        [SetUp]
        public void OncePerTest()
        {
            this.mockUserRepository = new Mock<IUserRepository>();
            this.mockSession = new Mock<ISession>();
            this.sut = new RegistrationService(this.mockUserRepository.Object, this.mockSession.Object);
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
            this.mockUserRepository.Verify(x => x.Insert(It.IsAny<object>()), Times.Once);
            this.mockUserRepository.Verify(x => x.Save(It.IsAny<User>()), Times.Once);
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
            this.mockUserRepository.Verify(x => x.Save(It.IsAny<User>()), Times.Once);
        }
    }
}
