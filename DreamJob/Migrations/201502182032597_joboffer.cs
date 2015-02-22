namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class joboffer : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOffers", "RecruiterId", "dbo.Recruiters");
            DropForeignKey("dbo.JobOffers", "DeveloperId", "dbo.Developers");
            DropIndex("dbo.JobOffers", new[] { "RecruiterId" });
            DropIndex("dbo.JobOffers", new[] { "DeveloperId" });
            DropTable("dbo.JobOffers");
        }
    }
}
