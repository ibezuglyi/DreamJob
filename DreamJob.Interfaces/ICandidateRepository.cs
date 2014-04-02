namespace DreamJob.Repositories
{
    public interface ICandidateRepository
    {
        void AllCandidates();
        void GetCandidateFullDetails(object isAny);
    }
}