namespace SecureDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataAnnotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TicketPriority", "TicketId", "dbo.Ticket");
            DropForeignKey("dbo.TicketStatus", "TicketId", "dbo.Ticket");
            DropForeignKey("dbo.TicketType", "Ticket_Id", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "TypeId_TypeId", "dbo.TicketType");
            DropIndex("dbo.TicketPriority", new[] { "TicketId" });
            DropIndex("dbo.Ticket", new[] { "TypeId_TypeId" });
            DropIndex("dbo.TicketStatus", new[] { "TicketId" });
            DropIndex("dbo.TicketType", new[] { "Ticket_Id" });
            RenameColumn(table: "dbo.Ticket", name: "TypeId_TypeId", newName: "TicketType_TypeId");
            AddColumn("dbo.Ticket", "TicketTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Ticket", "TicketStatusId", c => c.Int(nullable: false));
            AddColumn("dbo.Ticket", "TicketPriorityId", c => c.Int(nullable: false));
            AddColumn("dbo.Ticket", "TicketPriority_PriorityId", c => c.Int(nullable: false));
            AddColumn("dbo.Ticket", "TicketStatus_StatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Ticket", "TicketDescription", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Ticket", "NameOfFounder", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Ticket", "AssignedDeveloper", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Ticket", "TicketType_TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ticket", "TicketPriority_PriorityId");
            CreateIndex("dbo.Ticket", "TicketStatus_StatusId");
            CreateIndex("dbo.Ticket", "TicketType_TypeId");
            AddForeignKey("dbo.Ticket", "TicketPriority_PriorityId", "dbo.TicketPriority", "PriorityId", cascadeDelete: true);
            AddForeignKey("dbo.Ticket", "TicketStatus_StatusId", "dbo.TicketStatus", "StatusId", cascadeDelete: true);
            AddForeignKey("dbo.Ticket", "TicketType_TypeId", "dbo.TicketType", "TypeId", cascadeDelete: true);
            DropColumn("dbo.TicketType", "Ticket_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TicketType", "Ticket_Id", c => c.Int());
            DropForeignKey("dbo.Ticket", "TicketType_TypeId", "dbo.TicketType");
            DropForeignKey("dbo.Ticket", "TicketStatus_StatusId", "dbo.TicketStatus");
            DropForeignKey("dbo.Ticket", "TicketPriority_PriorityId", "dbo.TicketPriority");
            DropIndex("dbo.Ticket", new[] { "TicketType_TypeId" });
            DropIndex("dbo.Ticket", new[] { "TicketStatus_StatusId" });
            DropIndex("dbo.Ticket", new[] { "TicketPriority_PriorityId" });
            AlterColumn("dbo.Ticket", "TicketType_TypeId", c => c.Int());
            AlterColumn("dbo.Ticket", "AssignedDeveloper", c => c.String(maxLength: 25));
            AlterColumn("dbo.Ticket", "NameOfFounder", c => c.String(maxLength: 25));
            AlterColumn("dbo.Ticket", "TicketDescription", c => c.String(maxLength: 200));
            DropColumn("dbo.Ticket", "TicketStatus_StatusId");
            DropColumn("dbo.Ticket", "TicketPriority_PriorityId");
            DropColumn("dbo.Ticket", "TicketPriorityId");
            DropColumn("dbo.Ticket", "TicketStatusId");
            DropColumn("dbo.Ticket", "TicketTypeId");
            RenameColumn(table: "dbo.Ticket", name: "TicketType_TypeId", newName: "TypeId_TypeId");
            CreateIndex("dbo.TicketType", "Ticket_Id");
            CreateIndex("dbo.TicketStatus", "TicketId");
            CreateIndex("dbo.Ticket", "TypeId_TypeId");
            CreateIndex("dbo.TicketPriority", "TicketId");
            AddForeignKey("dbo.Ticket", "TypeId_TypeId", "dbo.TicketType", "TypeId");
            AddForeignKey("dbo.TicketType", "Ticket_Id", "dbo.Ticket", "Id");
            AddForeignKey("dbo.TicketStatus", "TicketId", "dbo.Ticket", "Id", cascadeDelete: true);
            AddForeignKey("dbo.TicketPriority", "TicketId", "dbo.Ticket", "Id", cascadeDelete: true);
        }
    }
}
