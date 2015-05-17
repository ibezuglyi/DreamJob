namespace DreamJob.ViewModels
{
    public class JobOfferContactDetailsViewModel
    {
        public JobOfferContactDetailsViewModel(ContactInformationViewModel ciViewModel)
        {
            this.ContactInfoViewModel = ciViewModel;
        }

        public ContactInformationViewModel ContactInfoViewModel { get; set; }
    }
}