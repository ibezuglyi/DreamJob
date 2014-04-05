namespace DreamJob.Interfaces
{
    public interface ICandidateSearchService
    {
        void GetAllCandidates();

        void GetCandidateDetails(object candidateId);
    }
}