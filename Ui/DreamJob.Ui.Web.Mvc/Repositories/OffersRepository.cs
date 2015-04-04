using System;

namespace DreamJob.Ui.Web.Mvc.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using DreamJob.Common.Enum;
    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    public class OffersRepository : IOffersRepository
    {
        private readonly DreamJobContext context;

        public OffersRepository(DreamJobContext context)
        {
            this.context = context;
        }

        public DjOperationResult<List<JobOffer>> OffersTo(long userId)
        {
            var offers = this.context
                .JobOffers.Where(x => x.ToDeveloperId == userId)
                .Include(offer => offer.FromRecruiter)
                .Include(offer=>offer.JobOfferComments)
                .OrderByDescending(offer=>offer.Add)
                .ToList();
            var result = new DjOperationResult<List<JobOffer>>(offers);
            return result;
        }

        public DjOperationResult<List<JobOffer>> OffersFrom(long recruiterId)
        {
            var offers = this.context
                .JobOffers.Where(x => x.FromRecruiterId == recruiterId)
                .Include(offer => offer.ToDeveloper)
                .Include(offer => offer.FromRecruiter)
                .Include(offer => offer.JobOfferComments)
                .OrderByDescending(offer => offer.Add)
                .ToList();
            var result = new DjOperationResult<List<JobOffer>>(offers);
            return result;
        }


        public DjOperationResult<JobOffer> GetDetails(long offerId)
        {
            var jobOffer = this.context.JobOffers.Include(offer => offer.FromRecruiter)
                .Include(offer => offer.ToDeveloper)
                .Include(offer => offer.JobOfferComments)
                .Include(offer => offer.JobOfferComments.Select(c => c.Author))
                .Single(offer => offer.Id == offerId);

            var result = new DjOperationResult<JobOffer>(jobOffer);
            return result;
        }

        public DjOperationResult<bool> InsertOffer(JobOffer jobOffer)
        {
            this.context.JobOffers.Add(jobOffer);
            this.context.SaveChanges();
            return DjOperationResult<bool>.Success();
        }

        public DjOperationResult<bool> UpdateStatus(long offerId, OfferStatus offerStatus, DateTime editTime)
        {
            var offerToUpdate = this.context.JobOffers.Single(o => o.Id == offerId);
            offerToUpdate.OfferStatus = offerStatus;
            offerToUpdate.Edit = editTime;
            this.context.SaveChanges();
            return DjOperationResult<bool>.Success();
        }

        public DjOperationResult<long> GetOffersCountTo(long toUserId, OfferStatus offerStatus)
        {
            var offersCount = this.context
                .JobOffers
                .Where(offer => offer.ToDeveloperId == toUserId)
                .Where(offer => offer.OfferStatus == offerStatus)
                .Count();

            var djOperationResult = new DjOperationResult<long>(offersCount);
            return djOperationResult;
        }
    }
}