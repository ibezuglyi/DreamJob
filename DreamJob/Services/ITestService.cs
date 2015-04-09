using DreamJob.ViewModels;

namespace DreamJob.Services
{
    public interface ITestService
    {
        void CreateNewDevelopers(int count);
        void CreateNewRecruites(int count);
        void CreateComments(int commentCounts, int offerCount);
        void CreateOffers(int count);
        void CreateOfferResponses(int count, int offersCount);
        void HijacIoc();
        void Restore();
        TestIndexViewModel GetViewModel();
    }
}