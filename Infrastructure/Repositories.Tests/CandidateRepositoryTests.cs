namespace DreamJob.Repositories.Tests
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;
    using DreamJob.Infrastructure.Repositories;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CandidateRepositoryTests
    {
        private CandidateRepository candidateRepository;
        private Mock<Candidate> persistanceContext;

        [SetUp]
        public void OncePerTest()
        {
            persistanceContext = new Mock<Candidate>();
            candidateRepository = new CandidateRepository(persistanceContext.Object);
        }

        [Test]
        public void T001_Can_Get_All_Candidates()
        {
            //arrange
            //persistanceContext

            var allCandidates = candidateRepository.GetAllCandidates();

            Assert.AreEqual(1, allCandidates.Count);
        }

    }
}
