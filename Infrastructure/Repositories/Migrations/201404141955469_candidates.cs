namespace DreamJob.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candidates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AboutMe = c.String(),
                        Login = c.String(),
                        PasswordHash = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Experiences",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Description = c.String(),
                        Candidate_Id = c.Long(),
                        Candidate_Id1 = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id1)
                .Index(t => t.Candidate_Id)
                .Index(t => t.Candidate_Id1);
            
            CreateTable(
                "dbo.JobRequirements",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Description = c.String(),
                        Currency = c.Int(nullable: false),
                        CurrencyAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        JobLocation_Country = c.String(),
                        JobLocation_City = c.String(),
                        Candidate_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.Candidate_Id)
                .Index(t => t.Candidate_Id);
            
            AddColumn("dbo.Tags", "Experience_Id", c => c.Long());
            AddColumn("dbo.Tags", "Candidate_Id", c => c.Long());
            CreateIndex("dbo.Tags", "Experience_Id");
            CreateIndex("dbo.Tags", "Candidate_Id");
            AddForeignKey("dbo.Tags", "Experience_Id", "dbo.Experiences", "Id");
            AddForeignKey("dbo.Tags", "Candidate_Id", "dbo.Candidates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Experiences", "Candidate_Id1", "dbo.Candidates");
            DropForeignKey("dbo.Tags", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.JobRequirements", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Experiences", "Candidate_Id", "dbo.Candidates");
            DropForeignKey("dbo.Tags", "Experience_Id", "dbo.Experiences");
            DropIndex("dbo.JobRequirements", new[] { "Candidate_Id" });
            DropIndex("dbo.Tags", new[] { "Candidate_Id" });
            DropIndex("dbo.Tags", new[] { "Experience_Id" });
            DropIndex("dbo.Experiences", new[] { "Candidate_Id1" });
            DropIndex("dbo.Experiences", new[] { "Candidate_Id" });
            DropColumn("dbo.Tags", "Candidate_Id");
            DropColumn("dbo.Tags", "Experience_Id");
            DropTable("dbo.JobRequirements");
            DropTable("dbo.Experiences");
            DropTable("dbo.Candidates");
        }
    }
}
