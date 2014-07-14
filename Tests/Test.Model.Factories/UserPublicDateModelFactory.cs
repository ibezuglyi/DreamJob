namespace Test.Model.Factories
{
    using DreamJob.Domain.Models;
    using DreamJob.Infrastructure.Interfaces;

    public class UserPublicDateModelFactory
    {
        public static UserPublicData CreateCandidate()
        {
            var result = new UserPublicData
                             {
                                 AccountType = UserAccountType.Candidate,
                                 Id = 2233,
                                 Login = "test-candidate-user-name"
                             };

            return result;
        }

        public static UserPublicData CreateRecruiter()
        {
            var result = new UserPublicData
                             {
                                 AccountType = UserAccountType.Recruiter,
                                 Id = 2233,
                                 Login = "test-recruiter-user-name"
                             };

            return result;
        }
    }
}