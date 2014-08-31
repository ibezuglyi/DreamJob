namespace DreamJob.Database.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Developers", "DeveloperId");
            DropColumn("dbo.Recruiters", "RecruiterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recruiters", "RecruiterId", c => c.Long(nullable: false));
            AddColumn("dbo.Developers", "DeveloperId", c => c.Long(nullable: false, identity: true));
        }
    }
}
