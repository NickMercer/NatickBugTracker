namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketTimesToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "TimeAssigned", c => c.DateTime());
            AlterColumn("dbo.Tickets", "TimeResolved", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "TimeResolved", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tickets", "TimeAssigned", c => c.DateTime(nullable: false));
        }
    }
}
