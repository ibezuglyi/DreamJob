namespace DreamJob.Services.Tests
{
    using DreamJob.Interfaces;
    using DreamJob.Models;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class OfferServiceTests
    {
        private IOfferService sut;

        private Mock<IOfferRepository> mockOfferRepository;

        [TestFixtureSetUp]
        public void Once()
        {
        }

        [SetUp]
        public void OncePerTest()
        {
        }


        [Test]
        public void T001_Recruiter_Can_Send_Job_Offer_To_A_Candidate()
        {
            // arrange
            object recruiterIdentificationData = null;
            object candidateIdentificationData = null;
            object offerIdentificationData = null;

            // arrange-mock

            // act
            this.sut.SendOffer(recruiterIdentificationData, candidateIdentificationData, offerIdentificationData);

            // assert

            // assert-mock
            this.mockOfferRepository.Verify(
                x => x.AddOffer(It.IsAny<object>(), It.IsAny<object>(), It.Is<JobOffer>(v => v.JobOfferStatus == JobOfferStatus.New)),
                Times.Once);
            this.mockOfferRepository.Verify(x => x.Save(), Times.Once);
        }


        [Test]
        public void T002_Candidate_Can_See_His_Offer_List()
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
            this.mockOfferRepository.Verify(x => x.Save(), Times.Once);
        }


        [Test]
        public void T003_Candidate_Can_Read_Job_Offer_Details()
        {
            // arrange
            object offerIdentificationData = null;

            // arrange-mock

            // act
            var result = this.sut.GetOfferDetails(offerIdentificationData, Roles.Candidate);

            // assert

            // assert-mock
            this.mockOfferRepository.Verify(x => x.GetOfferDetails(It.IsAny<object>()), Times.Once);
            this.mockOfferRepository.Verify(
                x => x.UpdateOfferStatus(It.Is<JobOfferStatus>(v => v == JobOfferStatus.Read)));
        }


        [Test]
        public void T004_Given_Job_Offer_Was_Already_Read_By_Candidate_When_He_Is_Intersted_In_Given_Position_Then_He_Can_Approve_Offer_And_Send_His_Contact_Details_To_The_Recruter()
        {
            // arrange
            object offerIdentificationData = null;
            object candidateContactData = null;

            // arrange-mock

            // act
            this.sut.AcceptOffer(offerIdentificationData, candidateContactData);

            // assert

            // assert-mock
            this.mockOfferRepository.Verify(
                x => x.UpdateOfferStatus(It.Is<JobOfferStatus>(v => v == JobOfferStatus.Accepted)),
                Times.Once);
        }


        [Test]
        public void T005_Given_Job_Offer_Send_To_Candidate_He_Can_Reject_It_Giving_Some_Information_Why_It_Was_Rejected()
        {
            // arrange
            object offerIdentificationData = null;
            object offerRejectFeedback = null;

            // arrange-mock

            // act
            this.sut.RejectOffer(offerIdentificationData, offerRejectFeedback);

            // assert

            // assert-mock
            this.mockOfferRepository.Verify(
                x => x.UpdateOfferStatus(It.Is<JobOfferStatus>(v => v == JobOfferStatus.Declined)),
                Times.Once);
        }


        [Test]
        public void T006_Given_Offer_Sent_To_Candidate_When_Recruiter_Reads_It_Again_Then_Status_Must_Not_Changed()
        {
            // arrange
            object offerIdentificationData = null;

            // arrange-mock

            // act
            var result = this.sut.GetOfferDetails(offerIdentificationData, Roles.Recruiter);

            // assert

            // assert-mock
            this.mockOfferRepository.Verify(x => x.UpdateOfferStatus(It.IsAny<JobOfferStatus>()), Times.Never);
        }
    }

    public enum Roles
    {
        Recruiter,

        Candidate
    }
}