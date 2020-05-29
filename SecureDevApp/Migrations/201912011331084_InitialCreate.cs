namespace SecureDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        Comments = c.String(),
                        CommentTimeStamp = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TicketPriority",
                c => new
                    {
                        PriorityId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        PriorityOfTicket = c.Int(),
                    })
                .PrimaryKey(t => t.PriorityId)
                .ForeignKey("dbo.Ticket", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TicketDescription = c.String(maxLength: 200),
                        DateCreated = c.DateTime(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        NameOfFounder = c.String(maxLength: 25),
                        AssignedDeveloper = c.String(maxLength: 25),
                        Comment_CommentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.Comment_CommentId)
                .Index(t => t.Comment_CommentId);
            
            CreateTable(
                "dbo.TicketStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        StatusOfTicket = c.Int(),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.Ticket", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.TicketType",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TicketId = c.Int(nullable: false),
                        TypeOfTicket = c.Int(),
                    })
                .PrimaryKey(t => t.TypeId)
                .ForeignKey("dbo.Ticket", t => t.TicketId, cascadeDelete: true)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TicketType", "TicketId", "dbo.Ticket");
            DropForeignKey("dbo.TicketStatus", "TicketId", "dbo.Ticket");
            DropForeignKey("dbo.TicketPriority", "TicketId", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "Comment_CommentId", "dbo.Comment");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.TicketType", new[] { "TicketId" });
            DropIndex("dbo.TicketStatus", new[] { "TicketId" });
            DropIndex("dbo.Ticket", new[] { "Comment_CommentId" });
            DropIndex("dbo.TicketPriority", new[] { "TicketId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TicketType");
            DropTable("dbo.TicketStatus");
            DropTable("dbo.Ticket");
            DropTable("dbo.TicketPriority");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Comment");
        }
    }
}
