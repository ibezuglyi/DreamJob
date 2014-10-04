namespace DreamJob.Database.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class developer_isLookingForJob : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "IsLookingForJob", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Developers", "IsLookingForJob");
        }
    }
}
