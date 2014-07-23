namespace DreamJob.Database.EntityFramework
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    using DreamJob.Model.Domain;

    public class DreamJobContext : DbContext
    {
        public DreamJobContext(string connectionName)
            : base(connectionName)
        {}

        public DreamJobContext():this("dreamjob.db")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Developer>().ToTable("Developers");
            modelBuilder.Entity<Recruiter>().ToTable("Recruiters");

            modelBuilder.Entity<Developer>().HasKey(x => x.DeveloperId);
            modelBuilder.Entity<Developer>()
                .Property(x => x.DeveloperId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<Developer>().HasMany(x => x.Skills).WithMany(x => x.Developers);
            modelBuilder.Entity<Developer>().HasMany(x => x.CompanyExperiences).WithMany(x => x.Developers);

            modelBuilder.Entity<Developer>()
                .HasMany(x => x.Skills)
                .WithMany(x => x.Developers)
                .Map(m => m.ToTable("DeveloperSkills"));

            modelBuilder.Entity<ProjectExperience>()
                .HasMany(x => x.Skills)
                .WithMany(x => x.ProjectExperiences)
                .Map(x => x.ToTable("ProjectExperiencesSkills"));

            modelBuilder.Entity<JobOffer>()
                .HasMany(x => x.RequiredSkills)
                .WithMany(x => x.JobOffers)
                .Map(x => x.ToTable("JobOffersSkills"));

            modelBuilder.Entity<Feedback>().HasRequired(x => x.Developer).WithMany(x => x.Feedbacks);
            modelBuilder.Entity<Feedback>().HasRequired(x => x.Recruiter).WithMany(x => x.Feedbacks);


        }

        public DbSet<User> Users { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
