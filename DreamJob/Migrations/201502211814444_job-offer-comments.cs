namespace DreamJob.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class joboffercomments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobOfferComments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AuthorId = c.Long(nullable: false),
                        Role = c.Int(nullable: false),
                        Text = c.String(),
                        JobOfferId = c.Long(nullable: false),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobOffers", t => t.JobOfferId, cascadeDelete: true)
                .Index(t => t.JobOfferId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobOfferComments", "JobOfferId", "dbo.JobOffers");
            DropIndex("dbo.JobOfferComments", new[] { "JobOfferId" });
            DropTable("dbo.JobOfferComments");
        }
    }
}
