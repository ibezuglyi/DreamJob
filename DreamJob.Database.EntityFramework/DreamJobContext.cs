using System.ComponentModel;

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
            modelBuilder.Entity<Developer>()
                .ToTable("Developers")
                .HasKey(x => x.DeveloperId)
                .Property(x => x.DeveloperId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Developer>().HasMany(x => x.Skills);
            modelBuilder.Entity<Developer>().HasMany(x => x.JobOffersReceived);
            modelBuilder.Entity<Recruiter>()
                .HasMany(r => r.Confirmations);

            modelBuilder.Entity<JobOffer>()
                .ToTable("JobOffer")
                .HasKey(r => r.Id)
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<JobOffer>().HasMany(r => r.JobOfferComments);
            modelBuilder.Entity<JobOffer>().HasRequired(r => r.FromRecruiter).WithMany(r => r.JobOffersSent);
            modelBuilder.Entity<JobOffer>().HasRequired(r => r.ToDeveloper).WithMany(r => r.JobOffersReceived);

            modelBuilder.Entity<JobOfferComment>()
                .ToTable("JobOfferComment")
                .HasKey(r => r.Id)
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Recruiter>()
                .ToTable("Recruiters")
                .HasKey(r=>r.Id)
                .Property(r=>r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Recruiter>()
                .HasMany(r => r.Feedbacks);
            modelBuilder.Entity<Recruiter>()
                .HasMany(r => r.JobOffersSent);
            modelBuilder.Entity<Recruiter>()
                .HasMany(r => r.Confirmations);
                

            modelBuilder.Entity<Skill>()
                .ToTable("Skill")
                .HasKey(r => r.Id)
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Feedback>()
                .ToTable("Feedback")
                .HasKey(r => r.Id)
                .Property(r=>r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Feedback>()
                .HasRequired(x => x.Recruiter)
                .WithMany(x => x.Feedbacks);

            modelBuilder.Entity<Confirmation>()
                .ToTable("Confirmation")
                .HasKey(r => r.Id)
                .Property(r => r.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Recruiter> Recruiters { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
