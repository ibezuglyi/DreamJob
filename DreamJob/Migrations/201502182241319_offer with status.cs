namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class offerwithstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffers", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOffers", "Status");
        }
    }
}
