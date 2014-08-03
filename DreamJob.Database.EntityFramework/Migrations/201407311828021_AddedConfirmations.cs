namespace DreamJob.Database.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedConfirmations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Confirmation",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ConfirmationCode = c.String(),
                        Add = c.DateTime(nullable: false),
                        Edit = c.DateTime(nullable: false),
                        User_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Users", "ConfirmationId", c => c.Long());
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Confirmation", "User_Id", "dbo.Users");
            DropIndex("dbo.Confirmation", new[] { "User_Id" });
            DropColumn("dbo.Users", "IsActive");
            DropColumn("dbo.Users", "ConfirmationId");
            DropTable("dbo.Confirmation");
        }
    }
}
