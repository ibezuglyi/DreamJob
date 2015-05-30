﻿using System.ComponentModel.DataAnnotations;

namespace DreamJob.ViewModels
{
    using System.Collections.Generic;

    public class JobOfferNewCommentViewModel
    {
        public JobOfferNewCommentViewModel()
            : this(0, new List<JobOfferStatus>())
        { }

        public JobOfferNewCommentViewModel(long id, List<JobOfferStatus> statuses)
        {
            this.Statuses = statuses;

            this.Text = string.Empty;
            this.JobOfferId = id;
        }

        public long JobOfferId { get; set; }
        [Display(ResourceType = typeof(Resources.Translations), Name = "JobOfferNewCommentViewModel_Text")]
        public string Text { get; set; }

        public List<JobOfferStatus> Statuses { get; set; }
    }
}