namespace DreamJob.Database.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class base_entity_uses_datetime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Add", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Users", "Edit", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Confirmation", "Add", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Confirmation", "Edit", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.JobOffer", "Add", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.JobOffer", "Edit", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Feedback", "Add", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Feedback", "Edit", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.JobOfferComment", "Add", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.JobOfferComment", "Edit", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Skill", "Add", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Skill", "Edit", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Skill", "Edit", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Skill", "Add", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobOfferComment", "Edit", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobOfferComment", "Add", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Feedback", "Edit", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Feedback", "Add", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobOffer", "Edit", c => c.DateTime(nullable: false));
            AlterColumn("dbo.JobOffer", "Add", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Confirmation", "Edit", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Confirmation", "Add", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Edit", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "Add", c => c.DateTime(nullable: false));
        }
    }
}
