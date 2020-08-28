namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProjectModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ProjectLeaderId = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ProjectedCompletionDate = c.DateTime(),
                        ActualCompletionDate = c.DateTime(),
                        StatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectStatus", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.ProjectStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "StatusId", "dbo.ProjectStatus");
            DropIndex("dbo.Projects", new[] { "StatusId" });
            DropTable("dbo.ProjectStatus");
            DropTable("dbo.Projects");
        }
    }
}
