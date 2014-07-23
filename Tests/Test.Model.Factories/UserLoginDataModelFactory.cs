namespace Test.Model.Factories
{
    using DreamJob.Services.Interfaces.Model;

    public class UserLoginDataModelFactory
    {
        public static UserLoginData CreateCandidate()
        {
            var result = new UserLoginData
                             {
                                 HashedPassword = "test-hashed-password-goes-here",
                                 Login = "test-candidate-user-name",
                                 RememberMe = true,
                             };

            return result;
        }

        public static UserLoginData CreateRecruiter()
        {
            var result = new UserLoginData
                             {
                                 HashedPassword = "test-hashed-password-goes-here",
                                 Login = "test-candidate-user-name",
                                 RememberMe = true,
                             };

            return result;
        }
    }
}