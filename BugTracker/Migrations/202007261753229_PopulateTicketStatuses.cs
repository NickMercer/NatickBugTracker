namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTicketStatuses : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TicketStatus (Name) VALUES ('Open')");
            Sql("INSERT INTO TicketStatus (Name) VALUES ('Assigned')");
            Sql("INSERT INTO TicketStatus (Name) VALUES ('Resolved')");
        }
        
        public override void Down()
        {
        }
    }
}
