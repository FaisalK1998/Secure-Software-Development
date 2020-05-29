namespace SecureDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTypeId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketType", "TicketId", "dbo.Ticket");
            DropIndex("dbo.TicketType", new[] { "TicketId" });
            AddColumn("dbo.Ticket", "TypeId_TypeId", c => c.Int());
            AddColumn("dbo.TicketType", "Ticket_Id", c => c.Int());
            CreateIndex("dbo.Ticket", "TypeId_TypeId");
            CreateIndex("dbo.TicketType", "Ticket_Id");
            AddForeignKey("dbo.Ticket", "TypeId_TypeId", "dbo.TicketType", "TypeId");
            AddForeignKey("dbo.TicketType", "Ticket_Id", "dbo.Ticket", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TicketType", "Ticket_Id", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "TypeId_TypeId", "dbo.TicketType");
            DropIndex("dbo.TicketType", new[] { "Ticket_Id" });
            DropIndex("dbo.Ticket", new[] { "TypeId_TypeId" });
            DropColumn("dbo.TicketType", "Ticket_Id");
            DropColumn("dbo.Ticket", "TypeId_TypeId");
            CreateIndex("dbo.TicketType", "TicketId");
            AddForeignKey("dbo.TicketType", "TicketId", "dbo.Ticket", "Id", cascadeDelete: true);
        }
    }
}
