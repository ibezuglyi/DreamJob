namespace DreamJob.Database.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Login = c.String(),
                        DisplayName = c.String(),
                        PasswordHash = c.String(),
                        Email = c.String(),
                        AccountType = c.Int(nullable: false),
                        Registered = c.DateTime(nullable: false),
                        LastLoginDateTime = c.DateTime(nullable: false),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobOffer",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FromRecruiterId = c.Long(nullable: false),
                        ToDeveloperId = c.Long(nullable: false),
                        Description = c.String(),
                        OfferStatus = c.Int(nullable: false),
                        MinSalary = c.Long(nullable: false),
                        MaxSalary = c.Long(),
                        MatchesDeveloperRequirements = c.Boolean(nullable: false),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recruiters", t => t.FromRecruiterId)
                .ForeignKey("dbo.Developers", t => t.ToDeveloperId)
                .Index(t => t.FromRecruiterId)
                .Index(t => t.ToDeveloperId);
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RecruiterId = c.Long(nullable: false),
                        DeveloperId = c.Long(nullable: false),
                        Text = c.String(),
                        FeedbackKind = c.Int(nullable: false),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.DeveloperId)
                .ForeignKey("dbo.Recruiters", t => t.RecruiterId)
                .Index(t => t.RecruiterId)
                .Index(t => t.DeveloperId);
            
            CreateTable(
                "dbo.JobOfferComment",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobOfferId = c.Long(nullable: false),
                        AuthorId = c.Long(nullable: false),
                        Text = c.String(),
                        Status = c.Int(nullable: false),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.JobOffer", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Skill",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        SelfRate = c.Int(nullable: false),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                        Developer_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.Developer_Id)
                .Index(t => t.Developer_Id);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        DeveloperId = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Profile = c.String(),
                        ProjectPreferences = c.String(),
                        MinSalary = c.Long(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Recruiters",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        RecruiterId = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Mobile = c.String(),
                        Company = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recruiters", "Id", "dbo.Users");
            DropForeignKey("dbo.Developers", "Id", "dbo.Users");
            DropForeignKey("dbo.Skill", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.JobOffer", "ToDeveloperId", "dbo.Developers");
            DropForeignKey("dbo.JobOfferComment", "JobOfferId", "dbo.JobOffer");
            DropForeignKey("dbo.JobOfferComment", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.JobOffer", "FromRecruiterId", "dbo.Recruiters");
            DropForeignKey("dbo.Feedback", "RecruiterId", "dbo.Recruiters");
            DropForeignKey("dbo.Feedback", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.Recruiters", new[] { "Id" });
            DropIndex("dbo.Developers", new[] { "Id" });
            DropIndex("dbo.Skill", new[] { "Developer_Id" });
            DropIndex("dbo.JobOfferComment", new[] { "AuthorId" });
            DropIndex("dbo.JobOfferComment", new[] { "JobOfferId" });
            DropIndex("dbo.Feedback", new[] { "DeveloperId" });
            DropIndex("dbo.Feedback", new[] { "RecruiterId" });
            DropIndex("dbo.JobOffer", new[] { "ToDeveloperId" });
            DropIndex("dbo.JobOffer", new[] { "FromRecruiterId" });
            DropTable("dbo.Recruiters");
            DropTable("dbo.Developers");
            DropTable("dbo.Skill");
            DropTable("dbo.JobOfferComment");
            DropTable("dbo.Feedback");
            DropTable("dbo.JobOffer");
            DropTable("dbo.Users");
        }
    }
}
