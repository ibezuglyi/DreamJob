namespace DreamJob.Models
{
    using System.Data.Entity;

    using DreamJob.Services;

    public class ApplicationDatabase : DbContext
    {
        public ApplicationDatabase()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public IDbSet<UserAccount> Profiles { get; set; }
        public IDbSet<Developer> Developers { get; set; }
        public IDbSet<Recruiter> Recruiters { get; set; }
        public IDbSet<DeveloperSkill> DeveloperSkills { get; set; }
        public IDbSet<Skill> Skills { get; set; }
        public IDbSet<JobOffer> JobOffers { get; set; }
        public IDbSet<JobOfferComment> JobOffersComments { get; set; }
        public IDbSet<JobOfferReject> JobOffersRejections { get; set; }
        public IDbSet<JobOfferCancel> JobOffersCancels { get; set; }
        public IDbSet<JobOfferAccept> JobOffersAccepts { get; set; }
        public IDbSet<JobOfferConfirm> JobOffersConfirms { get; set; }
    }
}