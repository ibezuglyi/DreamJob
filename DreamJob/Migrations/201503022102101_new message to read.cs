namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmessagetoread : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NewMessageToReads",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MessageType = c.Int(nullable: false),
                        UserAccountId = c.Long(nullable: false),
                        JobOfferId = c.Long(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccountId, cascadeDelete: true)
                .Index(t => t.UserAccountId)
                .Index(t => t.JobOfferId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewMessageToReads", "UserAccountId", "dbo.UserAccounts");
            DropForeignKey("dbo.NewMessageToReads", "JobOfferId", "dbo.JobOffers");
            DropIndex("dbo.NewMessageToReads", new[] { "JobOfferId" });
            DropIndex("dbo.NewMessageToReads", new[] { "UserAccountId" });
            DropTable("dbo.NewMessageToReads");
        }
    }
}
