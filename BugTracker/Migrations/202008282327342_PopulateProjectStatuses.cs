namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateProjectStatuses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO ProjectStatus (Name) VALUES ('Pre-Production')");
            Sql("INSERT INTO ProjectStatus (Name) VALUES ('In Production')");
            Sql("INSERT INTO ProjectStatus (Name) VALUES ('Released')");
            Sql("INSERT INTO ProjectStatus (Name) VALUES ('Cancelled')");
        }
        
        public override void Down()
        {
        }
    }
}
