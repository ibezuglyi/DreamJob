namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Note = c.String(),
                        JobOfferStatusChangeId = c.Long(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOfferStatusChanges", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.JobOfferStatusChanges",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobOfferId = c.Long(nullable: false),
                        Text = c.String(),
                        AuthorId = c.Long(nullable: false),
                        AuthorRole = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId);
            
            CreateTable(
                "dbo.Developers",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        DisplayName = c.String(),
                        AboutMe = c.String(),
                        LookingFor = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserAccountId = c.Long(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Email = c.String(),
                        PasswordHash = c.String(),
                        Role = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recruiters",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Employer = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        UserAccountId = c.Long(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserAccounts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.DeveloperSkills",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Level = c.Long(nullable: false),
                        SkillId = c.Long(nullable: false),
                        DeveloperId = c.Long(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.SkillId)
                .Index(t => t.DeveloperId);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.JobOffers",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobOfferText = c.String(),
                        Position = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyName = c.String(),
                        Requirements = c.String(),
                        OfferMatchesProfile = c.Boolean(nullable: false),
                        ProfileWasReadBeforeSending = c.Boolean(nullable: false),
                        DeveloperId = c.Long(nullable: false),
                        RecruiterId = c.Long(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .ForeignKey("dbo.Recruiters", t => t.RecruiterId, cascadeDelete: true)
                .Index(t => t.DeveloperId)
                .Index(t => t.RecruiterId);
            
            CreateTable(
                "dbo.JobOfferComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuthorId = c.Long(nullable: false),
                        AuthorRole = c.Int(nullable: false),
                        Text = c.String(),
                        JobOfferId = c.Long(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId);
            
            CreateTable(
                "dbo.webpages_Membership",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        CreateDate = c.DateTime(),
                        ConfirmationToken = c.String(maxLength: 128),
                        IsConfirmed = c.Boolean(),
                        LastPasswordFailureDate = c.DateTime(),
                        PasswordFailuresSinceLastSuccess = c.Int(nullable: false),
                        Password = c.String(nullable: false, maxLength: 128),
                        PasswordChangedDate = c.DateTime(),
                        PasswordSalt = c.String(nullable: false, maxLength: 128),
                        PasswordVerificationToken = c.String(maxLength: 128),
                        PasswordVerificationTokenExpirationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_OAuthMembership",
                c => new
                    {
                        Provider = c.String(nullable: false, maxLength: 30),
                        ProviderUserId = c.String(nullable: false, maxLength: 100),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider, t.ProviderUserId })
                .ForeignKey("dbo.webpages_Membership", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.webpages_UsersInRoles",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.webpages_Membership", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.webpages_Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.webpages_Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.webpages_UsersInRoles", "RoleId", "dbo.webpages_Roles");
            DropForeignKey("dbo.webpages_UsersInRoles", "UserId", "dbo.webpages_Membership");
            DropForeignKey("dbo.webpages_OAuthMembership", "UserId", "dbo.webpages_Membership");
            DropForeignKey("dbo.JobOfferStatusChanges", "JobOfferId", "dbo.JobOffers");
            DropForeignKey("dbo.JobOffers", "RecruiterId", "dbo.Recruiters");
            DropForeignKey("dbo.JobOfferComments", "JobOfferId", "dbo.JobOffers");
            DropForeignKey("dbo.JobOffers", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.DeveloperSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.DeveloperSkills", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.Developers", "Id", "dbo.UserAccounts");
            DropForeignKey("dbo.Recruiters", "Id", "dbo.UserAccounts");
            DropForeignKey("dbo.ContactInformations", "Id", "dbo.JobOfferStatusChanges");
            DropIndex("dbo.webpages_UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.webpages_UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.webpages_OAuthMembership", new[] { "UserId" });
            DropIndex("dbo.JobOfferComments", new[] { "JobOfferId" });
            DropIndex("dbo.JobOffers", new[] { "RecruiterId" });
            DropIndex("dbo.JobOffers", new[] { "DeveloperId" });
            DropIndex("dbo.DeveloperSkills", new[] { "DeveloperId" });
            DropIndex("dbo.DeveloperSkills", new[] { "SkillId" });
            DropIndex("dbo.Recruiters", new[] { "Id" });
            DropIndex("dbo.Developers", new[] { "Id" });
            DropIndex("dbo.JobOfferStatusChanges", new[] { "JobOfferId" });
            DropIndex("dbo.ContactInformations", new[] { "Id" });
            DropTable("dbo.webpages_Roles");
            DropTable("dbo.webpages_UsersInRoles");
            DropTable("dbo.webpages_OAuthMembership");
            DropTable("dbo.webpages_Membership");
            DropTable("dbo.JobOfferComments");
            DropTable("dbo.JobOffers");
            DropTable("dbo.Skills");
            DropTable("dbo.DeveloperSkills");
            DropTable("dbo.Recruiters");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Developers");
            DropTable("dbo.JobOfferStatusChanges");
            DropTable("dbo.ContactInformations");
        }
    }
}
