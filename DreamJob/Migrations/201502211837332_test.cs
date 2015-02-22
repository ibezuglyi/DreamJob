namespace DreamJob.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class RoleInCommentRenamedToAuthorRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobOfferComments", "AuthorRole", c => c.Int(nullable: false));
            DropColumn("dbo.JobOfferComments", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.JobOfferComments", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.JobOfferComments", "AuthorRole");
        }
    }
}
