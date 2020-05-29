namespace SecureDevApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'249ffc0f-5022-49df-800a-c925d5c02264', N'guest@testing.com', 0, N'ANR6+SciY6MCjHcawsIbBjvce/Why0tQ0cnNlwJFuI+SoTsF1bX2ouNsEDPEa8SJzw==', N'527643d3-5c48-4337-b9e3-8c7ae1084796', NULL, 0, 0, NULL, 1, 0, N'guest@testing.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'40fe3d5f-f99b-4a7d-9e77-3994b2d124e1', N'developer@testing.com', 0, N'AIX+1XQrZej5fD/+o2ibEEEPMzh5WcE/x/m/1kc0udy0JOrp+lDv5qQzBUZTOAfl+Q==', N'30ac1cde-89ac-4e36-ac77-53fb559bae75', NULL, 0, 0, NULL, 1, 0, N'developer@testing.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'779eebf8-ff41-4870-8179-d749a039772d', N'Tester@testing.com', 0, N'ALzOgxEd5kolX+VuFAe8IrxYQyBzWo6jKot1AKCcfF0p1VrJjdIuYGKb1tV50ba3gA==', N'30a8914f-d821-4cd7-af54-d8a974e9acd2', NULL, 0, 0, NULL, 1, 0, N'Tester@testing.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0ed929f2-ae1b-4958-9ad8-f4a94d001f5f', N'CanManageTickets')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'40fe3d5f-f99b-4a7d-9e77-3994b2d124e1', N'0ed929f2-ae1b-4958-9ad8-f4a94d001f5f')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'779eebf8-ff41-4870-8179-d749a039772d', N'0ed929f2-ae1b-4958-9ad8-f4a94d001f5f')

");
        }
        
        public override void Down()
        {
        }
    }
}
