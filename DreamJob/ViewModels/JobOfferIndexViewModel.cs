namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    public class JobOfferIndexViewModel
    {
        public List<JobOfferHeadlineViewModel> OffersList { get; set; }

        public JobOfferIndexViewModel(List<JobOfferHeadlineViewModel> offersList)
        {
            this.OffersList = offersList;
        }
    }
}