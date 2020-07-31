namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusIdToTickets : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Tickets", name: "Status_Id", newName: "StatusId");
            RenameIndex(table: "dbo.Tickets", name: "IX_Status_Id", newName: "IX_StatusId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Tickets", name: "IX_StatusId", newName: "IX_Status_Id");
            RenameColumn(table: "dbo.Tickets", name: "StatusId", newName: "Status_Id");
        }
    }
}
