namespace DreamJob.Ui.Web.Mvc.Controllers
{
    using System;
    using System.Collections.Generic;

    using DreamJob.Common.Enum;
    using DreamJob.Model.Domain;
    using DreamJob.Ui.Web.Mvc.Models.Dto;

    public interface IOffersLogic
    {
        DjOperationResult<List<JobOfferDto>> GetOffersForUser(long userId);
        DjOperationResult<JobOfferDetailsDto> GetDetailsForOffer(long offerId);
    }

    public class JobOfferDetailsDto
    {
        public long Id { get; set; }
        public DateTime Add { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public OfferStatus OfferStatus { get; set; }
        public long MinSalary { get; set; }
        public long? MaxSalary { get; set; }
        public bool MatchesDeveloperRequirements { get; set; }
        public List<JobOfferCommentDto> JobOfferComments { get; set; }
    }

    public class JobOfferCommentDto
    {
        public long Id { get; set; }
        public DateTime Add { get; set; }
        public long JobOfferId { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public JobOfferCommentStatus Status { get; set; }
    }
}