namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobofferstatusesintoseparatetables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOfferAccepts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobOfferId = c.Long(nullable: false),
                        Text = c.String(),
                        AuthorId = c.Long(nullable: false),
                        AuthorRole = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId);
            
            CreateTable(
                "dbo.JobOfferCancels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobOfferId = c.Long(nullable: false),
                        Text = c.String(),
                        AuthorId = c.Long(nullable: false),
                        AuthorRole = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId);
            
            CreateTable(
                "dbo.JobOfferConfirms",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        JobOfferId = c.Long(nullable: false),
                        Text = c.String(),
                        AuthorId = c.Long(nullable: false),
                        AuthorRole = c.Int(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId);
            
            CreateTable(
                "dbo.JobOfferRejects",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuthorId = c.Long(nullable: false),
                        AuthorRole = c.Int(nullable: false),
                        JobOfferId = c.Long(nullable: false),
                        Text = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOfferRejects", "JobOfferId", "dbo.JobOffers");
            DropForeignKey("dbo.JobOfferConfirms", "JobOfferId", "dbo.JobOffers");
            DropForeignKey("dbo.JobOfferCancels", "JobOfferId", "dbo.JobOffers");
            DropForeignKey("dbo.JobOfferAccepts", "JobOfferId", "dbo.JobOffers");
            DropIndex("dbo.JobOfferRejects", new[] { "JobOfferId" });
            DropIndex("dbo.JobOfferConfirms", new[] { "JobOfferId" });
            DropIndex("dbo.JobOfferCancels", new[] { "JobOfferId" });
            DropIndex("dbo.JobOfferAccepts", new[] { "JobOfferId" });
            DropTable("dbo.JobOfferRejects");
            DropTable("dbo.JobOfferConfirms");
            DropTable("dbo.JobOfferCancels");
            DropTable("dbo.JobOfferAccepts");
        }
    }
}
