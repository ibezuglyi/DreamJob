namespace DreamJob.ViewModels
{
    public class TestIndexViewModel
    {
        public bool IsHijacked { get; set; }

        public TestIndexViewModel(bool isHijacked)
        {
            this.IsHijacked = isHijacked;
        }
    }
}