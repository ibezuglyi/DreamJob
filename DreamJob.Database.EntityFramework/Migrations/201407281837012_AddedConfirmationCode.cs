namespace DreamJob.Database.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConfirmationCode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmationCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ConfirmationCode");
        }
    }
}
