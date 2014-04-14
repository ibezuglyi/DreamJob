namespace DreamJob.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tag_recruiter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recruiters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Login = c.String(),
                        PasswordHash = c.String(),
                        EmailAddress = c.String(),
                        Company_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recruiters", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Recruiters", new[] { "Company_Id" });
            DropTable("dbo.Tags");
            DropTable("dbo.Recruiters");
        }
    }
}
