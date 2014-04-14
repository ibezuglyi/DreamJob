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

        }

        [Test]
        public void T001_Can_Get_All_Candidates()
        {
            //arrange
            //persistanceContext


        }

    }
}
