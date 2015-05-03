namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class experience : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "ExperienceInYears", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Developers", "ExperienceInYears");
        }
    }
}
