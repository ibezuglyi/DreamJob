namespace DreamJob.Services.Tests
{
    using DreamJob.Domain.Models;
    using DreamJob.Interfaces;
    using DreamJob.Services.Interfaces;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class JobOfferServiceTests
    {
        private IJobOfferService sut;

        private Mock<IJobOfferRepository> mockOfferRepository;

        [TestFixtureSetUp]
        public void Once()
        {
        }

        [SetUp]
        public void OncePerTest()
        {
            this.mockOfferRepository = new Mock<IJobOfferRepository>();
            this.sut = new JobOfferService(this.mockOfferRepository.Object);
        }


        [Test]
        public void T001()
        {
            // arrange
            long recruiterIdentificationData = 123;
            long candidateIdentificationData = 321;
            long offerIdentificationData = 333;

            // arrange-mock

            // act
            this.sut.SendOffer(recruiterIdentificationData, candidateIdentificationData, offerIdentificationData);

            // assert

            // assert-mock
            this.mockOfferRepository.Verify(
                x => x.AddOffer(It.IsAny<object>(), It.IsAny<object>(), It.Is<JobOffer>(v => v.JobOfferStatus == JobOfferStatus.New)),
                Times.Once);
            this.mockOfferRepository.Verify(x => x.Save(It.IsAny<JobOffer>()), Times.Once);
        }


        [Test]
        public void T002()
        {
            // arrange
            object candidateIdentificationData = null;

            // arrange-mock

            // act
            object result = this.sut.GetAllOffersForCandidate(candidateIdentificationData);

            // assert
            Assert.NotNull(result);

            // assert-mock
            this.mockOfferRepository.Verify(x => x.GetAllOffersForCandidate(It.IsAny<object>()), Times.Once);
            this.mockOfferRepository.Verify(x => x.MarkOffersRead(It.IsAny<object>()), Times.Once);
            this.mockOfferRepository.Verify(x => x.Save(It.IsAny<JobOffer>()), Times.Once);
        }


        [Test]
        public void T003()
        {
            // arrange
            object offerIdentificationData = null;

            // arrange-mock

            // act
            var result = this.sut.GetOfferDetails(offerIdentificationData);

            // assert

            // assert-mock
            this.mockOfferRepository.Verify(x => x.GetOfferDetails(It.IsAny<object>()), Times.Once);
            this.mockOfferRepository.Verify(
                x => x.UpdateOfferStatus(It.Is<JobOfferStatus>(v => v == JobOfferStatus.Read)));
        }


        [Test]
        public void T()
        {
            // arrange
            object offerIdentificationData = null;
            object candidateContactData = null;
            
            // arrange-mock

            // act
            this.sut.AcceptOffer(offerIdentificationData, candidateContactData);

            // assert

            // assert-mock
        }
    }
}