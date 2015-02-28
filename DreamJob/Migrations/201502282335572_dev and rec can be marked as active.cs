namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class devandreccanbemarkedasactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recruiters", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recruiters", "IsActive");
            DropColumn("dbo.Developers", "IsActive");
        }
    }
}
