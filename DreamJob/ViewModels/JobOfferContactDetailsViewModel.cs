namespace DreamJob.ViewModels
{
    using System;

    public class JobOfferContactDetailsViewModel
    {
        public JobOfferContactDetailsViewModel(ContactInformationViewModel ciViewModel)
        {
            this.ContactInfoViewModel = ciViewModel;
        }

        public ContactInformationViewModel ContactInfoViewModel { get; set; }
    }
}