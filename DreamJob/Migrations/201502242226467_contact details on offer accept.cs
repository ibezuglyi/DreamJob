namespace DreamJob.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class contactdetailsonofferaccept : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContactInformations",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Note = c.String(),
                        CreateDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);

            AddColumn("dbo.JobOfferAccepts", "ContactInformationId", c => c.Long(nullable: false));
            CreateIndex("dbo.JobOfferAccepts", "ContactInformationId");

            AddForeignKey("dbo.JobOfferAccepts", "ContactInformationId", "dbo.ContactInformations", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            DropForeignKey("dbo.JobOfferAccepts", "ContactInformationId", "dbo.ContactInformations");
            DropIndex("dbo.JobOfferAccepts", new[] { "ContactInformationId" });
            DropColumn("dbo.JobOfferAccepts", "ContactInformationId");
            DropTable("dbo.ContactInformations");
        }
    }
}
