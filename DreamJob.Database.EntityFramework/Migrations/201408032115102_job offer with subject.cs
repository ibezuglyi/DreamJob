namespace DreamJob.Database.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobofferwithsubject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOffer", "Subject", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobOffer", "Subject");
        }
    }
}
