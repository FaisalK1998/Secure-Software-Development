namespace SecureDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatesToAnotations : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TicketType", "TypeOfTicket", c => c.Int());
            AlterColumn("dbo.TicketStatus", "StatusOfTicket", c => c.Int());
            AlterColumn("dbo.TicketPriority", "PriorityOfTicket", c => c.Int());
        }
    }
}
