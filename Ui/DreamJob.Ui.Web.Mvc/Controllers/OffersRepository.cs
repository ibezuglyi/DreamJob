namespace DreamJob.Ui.Web.Mvc.Areas.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using DreamJob.Database.EntityFramework;
    using DreamJob.Model.Domain;

    public class OffersRepository : IOffersRepository
    {
        private readonly DreamJobContext context;

        public OffersRepository(DreamJobContext context)
        {
            this.context = context;
        }

        public List<JobOffer> OffersTo(long userId)
        {
            var offers = this.context.JobOffers.Where(x => x.ToDeveloperId == userId).ToList();
            return offers;
        }
    }
}