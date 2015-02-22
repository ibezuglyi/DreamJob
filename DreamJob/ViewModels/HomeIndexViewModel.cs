namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    public class HomeIndexViewModel
    {
        public List<DeveloperHeadlineViewModel> Headlines { get; set; }

        public HomeIndexViewModel(List<DeveloperHeadlineViewModel> headlines)
        {
            this.Headlines = headlines;
        }
    }
}