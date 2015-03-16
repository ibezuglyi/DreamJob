namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentwithauthor : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.JobOfferComments", "AuthorId");
            AddForeignKey("dbo.JobOfferComments", "AuthorId", "dbo.UserAccounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOfferComments", "AuthorId", "dbo.UserAccounts");
            DropIndex("dbo.JobOfferComments", new[] { "AuthorId" });
        }
    }
}
