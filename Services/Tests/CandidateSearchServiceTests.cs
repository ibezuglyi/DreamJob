namespace DreamJob.Services.Tests
{
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Services.Interfaces;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class CandidateServiceTests
    {
        private ICandidateService sut;

        private Mock<ICandidateRepository> mockCandidateRepository;

        [TestFixtureSetUp]
        public void Once()
        {
        }

        [SetUp]
        public void OncePerTest()
        {
            this.mockCandidateRepository = new Mock<ICandidateRepository>();
            this.sut = new CandidateService(this.mockCandidateRepository.Object);
        }


        [Test]
        public void T001()
        {
            // arrange

            // arrange-mock

            // act
            this.sut.GetAllCandidates();

            // assert

            // assert-mock
            this.mockCandidateRepository.Verify(x => x.GetAllCandidates(), Times.Once());
        }


        [Test]
        public void T002()
        {
            // arrange
            object candidateId = null;

            // arrange-mock

            // act
            this.sut.GetCandidateDetails(candidateId);

            // assert

            // assert-mock
            this.mockCandidateRepository.Verify(x => x.GetCandidateFullDetails(It.IsAny<object>()), Times.Once);
        }
    }
}