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
    }
}