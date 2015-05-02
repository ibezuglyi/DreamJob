namespace DreamJob.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class candidate_working_location : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Developers", "CurrentWorkingLocation", c => c.String(nullable: false, defaultValueSql: string.Empty));
            AddColumn("dbo.Developers", "WillingToRelocateToDifferentCity", c => c.Boolean(nullable: false));
            AddColumn("dbo.Developers", "WillingToRelocateToDifferentCountry", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Developers", "WillingToRelocateToDifferentCountry");
            DropColumn("dbo.Developers", "WillingToRelocateToDifferentCity");
            DropColumn("dbo.Developers", "CurrentWorkingLocation");
        }
    }
}
