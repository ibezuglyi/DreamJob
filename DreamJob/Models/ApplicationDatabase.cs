namespace DreamJob.Models
{
    using System.Data.Entity;

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
        public IDbSet<JobOfferStatusChange> JobOfferStatusChanges { get; set; }
        public IDbSet<ContactInformation> ContactInformations { get; set; } 



        public IDbSet<UsersInRole> UsersInRoles { get; set; }
        public IDbSet<Role> Roles { get; set; }
        public IDbSet<OAuthMembership> OAuthMemberships { get; set; }
        public IDbSet<Membership> Memberships { get; set; }
    }
}