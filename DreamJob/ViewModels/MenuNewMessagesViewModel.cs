namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    using Models;

    public class MenuNewMessagesViewModel
    {
        public MenuNewMessagesViewModel(Dictionary<ApplicationMessageType, int> dictionary)
        {
            this.CountOfNewJobOffers = dictionary.ContainsKey(ApplicationMessageType.JobOffer)
                                           ? dictionary[ApplicationMessageType.JobOffer]
                                           : 0;

            this.CountOfNewJobOffersComments = dictionary.ContainsKey(ApplicationMessageType.Comment)
                                           ? dictionary[ApplicationMessageType.Comment]
                                           : 0;

            this.CountOfNewJobOffersStatusChanges = dictionary.ContainsKey(ApplicationMessageType.Status)
                                           ? dictionary[ApplicationMessageType.Status]
                                           : 0;
        }

        public long AllMessagesCount()
        {
            return this.CountOfNewJobOffers + this.CountOfNewJobOffersComments + this.CountOfNewJobOffersStatusChanges;
        }

        public long CountOfNewJobOffersStatusChanges { get; set; }
        public long CountOfNewJobOffersComments { get; set; }
        public long CountOfNewJobOffers { get; set; }
    }
}