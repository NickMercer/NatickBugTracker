namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDeveloperProjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeveloperProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeveloperId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DeveloperProjects");
        }
    }
}
