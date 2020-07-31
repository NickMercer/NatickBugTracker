namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTicketsAndStatuses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false, maxLength: 255),
                        Description = c.String(nullable: false),
                        TimeOpened = c.DateTime(nullable: false),
                        TimeAssigned = c.DateTime(nullable: false),
                        TimeResolved = c.DateTime(nullable: false),
                        Status_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketStatus", t => t.Status_Id, cascadeDelete: true)
                .Index(t => t.Status_Id);
            
            CreateTable(
                "dbo.TicketStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Status_Id", "dbo.TicketStatus");
            DropIndex("dbo.Tickets", new[] { "Status_Id" });
            DropTable("dbo.TicketStatus");
            DropTable("dbo.Tickets");
        }
    }
}
