namespace DreamJob.Repositories.Tests
{
    using DreamJob.Interfaces;

    using NUnit.Framework;

    [TestFixture]
    public class UserRepositoryTests
    {
        private IUserRepository sut;

        [TestFixtureSetUp]
        public void Once()
        {
        }

        [SetUp]
        public void OncePerTest()
        {
        }


        [Test]
        public void T001()
        {
            // arrange
            object userData = null;

            // arrange-mock

            // act
            this.sut.Insert(userData);

            // assert

            // assert-mock
        }
    }
}
