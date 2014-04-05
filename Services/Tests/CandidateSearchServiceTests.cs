namespace DreamJob.Services.Tests
{
    using DreamJob.Interfaces;
    using DreamJob.Repositories;
    using DreamJob.Services.CandidateSearchService;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class CandidateSearchServiceTests
    {
        private ICandidateSearchService sut;

        private Mock<ICandidateRepository> mockCandidateRepository;

        [TestFixtureSetUp]
        public void Once()
        {
        }

        [SetUp]
        public void OncePerTest()
        {
            this.mockCandidateRepository = new Mock<ICandidateRepository>();
            this.sut = new CandidateSearchService(this.mockCandidateRepository.Object);
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
            this.mockCandidateRepository.Verify(x => x.AllCandidates(), Times.Once());
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