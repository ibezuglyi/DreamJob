namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeveloperSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.DeveloperSkills", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.Developers", "Id", "dbo.UserAccounts");
            DropForeignKey("dbo.Recruiters", "Id", "dbo.UserAccounts");
            DropIndex("dbo.DeveloperSkills", new[] { "DeveloperId" });
            DropIndex("dbo.DeveloperSkills", new[] { "SkillId" });
            DropIndex("dbo.Recruiters", new[] { "Id" });
            DropIndex("dbo.Developers", new[] { "Id" });
            DropTable("dbo.Skills");
            DropTable("dbo.DeveloperSkills");
            DropTable("dbo.Recruiters");
            DropTable("dbo.UserAccounts");
            DropTable("dbo.Developers");
        }
    }
}
