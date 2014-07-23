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
                "dbo.CompanyExperiences",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmployerId = c.Long(nullable: false),
                        PositionId = c.Long(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.EmployerId, cascadeDelete: true)
                .ForeignKey("dbo.WorkPositions", t => t.PositionId, cascadeDelete: true)
                .Index(t => t.EmployerId)
                .Index(t => t.PositionId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WorkPositions",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Feedbacks",
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
                "dbo.JobOffers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FromRecruiterId = c.Long(nullable: false),
                        ToDeveloperId = c.Long(nullable: false),
                        Description = c.String(),
                        OfferStatus = c.Int(nullable: false),
                        TargetCompanyId = c.Long(nullable: false),
                        TargetWorkPositionId = c.Long(nullable: false),
                        SalaryRangeId = c.Long(nullable: false),
                        MatchesDeveloperRequirements = c.Boolean(nullable: false),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recruiters", t => t.FromRecruiterId)
                .ForeignKey("dbo.SalaryRanges", t => t.SalaryRangeId, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.TargetCompanyId, cascadeDelete: true)
                .ForeignKey("dbo.WorkPositions", t => t.TargetWorkPositionId, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.ToDeveloperId)
                .Index(t => t.FromRecruiterId)
                .Index(t => t.ToDeveloperId)
                .Index(t => t.TargetCompanyId)
                .Index(t => t.TargetWorkPositionId)
                .Index(t => t.SalaryRangeId);
            
            CreateTable(
                "dbo.JobOfferComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobOfferId = c.Long(nullable: false),
                        AuthorId = c.Long(nullable: false),
                        Text = c.String(),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectExperiences",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Description = c.String(),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                        Developer_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.Developer_Id)
                .Index(t => t.Developer_Id);
            
            CreateTable(
                "dbo.SalaryRanges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Low = c.Long(nullable: false),
                        High = c.Long(nullable: false),
                        Currency = c.Int(nullable: false),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeveloperCompanyExperiences",
                c => new
                    {
                        Developer_Id = c.Long(nullable: false),
                        CompanyExperience_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Developer_Id, t.CompanyExperience_Id })
                .ForeignKey("dbo.Developers", t => t.Developer_Id, cascadeDelete: true)
                .ForeignKey("dbo.CompanyExperiences", t => t.CompanyExperience_Id, cascadeDelete: true)
                .Index(t => t.Developer_Id)
                .Index(t => t.CompanyExperience_Id);
            
            CreateTable(
                "dbo.ProjectExperiencesSkills",
                c => new
                    {
                        ProjectExperience_Id = c.Long(nullable: false),
                        Skill_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectExperience_Id, t.Skill_Id })
                .ForeignKey("dbo.ProjectExperiences", t => t.ProjectExperience_Id, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .Index(t => t.ProjectExperience_Id)
                .Index(t => t.Skill_Id);
            
            CreateTable(
                "dbo.JobOffersSkills",
                c => new
                    {
                        JobOffer_Id = c.Long(nullable: false),
                        Skill_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.JobOffer_Id, t.Skill_Id })
                .ForeignKey("dbo.JobOffers", t => t.JobOffer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .Index(t => t.JobOffer_Id)
                .Index(t => t.Skill_Id);
            
            CreateTable(
                "dbo.DeveloperSkills",
                c => new
                    {
                        Developer_Id = c.Long(nullable: false),
                        Skill_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Developer_Id, t.Skill_Id })
                .ForeignKey("dbo.Developers", t => t.Developer_Id, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Skill_Id, cascadeDelete: true)
                .Index(t => t.Developer_Id)
                .Index(t => t.Skill_Id);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        DeveloperId = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
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
                        UserId = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Mobile = c.String(),
                        CurrentEmployerId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CurrentEmployerId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.CurrentEmployerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recruiters", "CurrentEmployerId", "dbo.Companies");
            DropForeignKey("dbo.Recruiters", "Id", "dbo.Users");
            DropForeignKey("dbo.Developers", "Id", "dbo.Users");
            DropForeignKey("dbo.DeveloperSkills", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.DeveloperSkills", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.ProjectExperiences", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.Feedbacks", "RecruiterId", "dbo.Recruiters");
            DropForeignKey("dbo.JobOffers", "ToDeveloperId", "dbo.Developers");
            DropForeignKey("dbo.JobOffers", "TargetWorkPositionId", "dbo.WorkPositions");
            DropForeignKey("dbo.JobOffers", "TargetCompanyId", "dbo.Companies");
            DropForeignKey("dbo.JobOffers", "SalaryRangeId", "dbo.SalaryRanges");
            DropForeignKey("dbo.JobOffersSkills", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.JobOffersSkills", "JobOffer_Id", "dbo.JobOffers");
            DropForeignKey("dbo.ProjectExperiencesSkills", "Skill_Id", "dbo.Skills");
            DropForeignKey("dbo.ProjectExperiencesSkills", "ProjectExperience_Id", "dbo.ProjectExperiences");
            DropForeignKey("dbo.JobOfferComments", "JobOfferId", "dbo.JobOffers");
            DropForeignKey("dbo.JobOfferComments", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.JobOffers", "FromRecruiterId", "dbo.Recruiters");
            DropForeignKey("dbo.Feedbacks", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.DeveloperCompanyExperiences", "CompanyExperience_Id", "dbo.CompanyExperiences");
            DropForeignKey("dbo.DeveloperCompanyExperiences", "Developer_Id", "dbo.Developers");
            DropForeignKey("dbo.CompanyExperiences", "PositionId", "dbo.WorkPositions");
            DropForeignKey("dbo.CompanyExperiences", "EmployerId", "dbo.Companies");
            DropIndex("dbo.Recruiters", new[] { "CurrentEmployerId" });
            DropIndex("dbo.Recruiters", new[] { "Id" });
            DropIndex("dbo.Developers", new[] { "Id" });
            DropIndex("dbo.DeveloperSkills", new[] { "Skill_Id" });
            DropIndex("dbo.DeveloperSkills", new[] { "Developer_Id" });
            DropIndex("dbo.JobOffersSkills", new[] { "Skill_Id" });
            DropIndex("dbo.JobOffersSkills", new[] { "JobOffer_Id" });
            DropIndex("dbo.ProjectExperiencesSkills", new[] { "Skill_Id" });
            DropIndex("dbo.ProjectExperiencesSkills", new[] { "ProjectExperience_Id" });
            DropIndex("dbo.DeveloperCompanyExperiences", new[] { "CompanyExperience_Id" });
            DropIndex("dbo.DeveloperCompanyExperiences", new[] { "Developer_Id" });
            DropIndex("dbo.ProjectExperiences", new[] { "Developer_Id" });
            DropIndex("dbo.JobOfferComments", new[] { "AuthorId" });
            DropIndex("dbo.JobOfferComments", new[] { "JobOfferId" });
            DropIndex("dbo.JobOffers", new[] { "SalaryRangeId" });
            DropIndex("dbo.JobOffers", new[] { "TargetWorkPositionId" });
            DropIndex("dbo.JobOffers", new[] { "TargetCompanyId" });
            DropIndex("dbo.JobOffers", new[] { "ToDeveloperId" });
            DropIndex("dbo.JobOffers", new[] { "FromRecruiterId" });
            DropIndex("dbo.Feedbacks", new[] { "DeveloperId" });
            DropIndex("dbo.Feedbacks", new[] { "RecruiterId" });
            DropIndex("dbo.CompanyExperiences", new[] { "PositionId" });
            DropIndex("dbo.CompanyExperiences", new[] { "EmployerId" });
            DropTable("dbo.Recruiters");
            DropTable("dbo.Developers");
            DropTable("dbo.DeveloperSkills");
            DropTable("dbo.JobOffersSkills");
            DropTable("dbo.ProjectExperiencesSkills");
            DropTable("dbo.DeveloperCompanyExperiences");
            DropTable("dbo.SalaryRanges");
            DropTable("dbo.ProjectExperiences");
            DropTable("dbo.Skills");
            DropTable("dbo.JobOfferComments");
            DropTable("dbo.JobOffers");
            DropTable("dbo.Feedbacks");
            DropTable("dbo.WorkPositions");
            DropTable("dbo.Companies");
            DropTable("dbo.CompanyExperiences");
            DropTable("dbo.Users");
        }
    }
}
