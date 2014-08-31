﻿namespace DreamJob.Ui.Web.Mvc.Models.Dto
{
    using System;
    using System.Collections.Generic;

    public class JobOfferDetailsDto
    {
        public long Id { get; set; }
        public DateTime Add { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string OfferStatus { get; set; }
        public long MinSalary { get; set; }
        public long? MaxSalary { get; set; }
        public bool MatchesDeveloperRequirements { get; set; }
        public List<JobOfferCommentDto> JobOfferComments { get; set; }
    }
}