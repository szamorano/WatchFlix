namespace WatchFlix.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'391362ae-9e56-4afe-b0b2-6fb0f70dd5ef', N'admin@watchflix.com', 0, N'AHHXz1Dkf5UyrS6RuG0/wGe+9Frp1EhSlnlYDkadd/n2fiHrDxH8K7xn3JvGMSbP4Q==', N'a747463c-3dd7-460a-9aa2-71e8e09949e4', NULL, 0, 0, NULL, 1, 0, N'admin@watchflix.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9cad08f3-e342-4682-98ec-6cc0a8347a3e', N'guest@watchflix.com', 0, N'AOPbxH2MCY2DJ57wcNCa8H2CCZzQ7t1bdV2DCMTY0TAJBxNtqg9UV3013OU35ZZ5nQ==', N'86e5357a-f52b-4f7b-ba93-48b7f4927ead', NULL, 0, 0, NULL, 1, 0, N'guest@watchflix.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'69c0bd13-a3d8-4257-96c9-591bc3e65b59', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'391362ae-9e56-4afe-b0b2-6fb0f70dd5ef', N'69c0bd13-a3d8-4257-96c9-591bc3e65b59')

");
        }
        
        public override void Down()
        {
        }
    }
}
