namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'393085c7-413a-47c3-9445-6dbf46c8cfd4', N'admin@vidly.com', 0, N'AM50LP7QFWy6Hj13PFQmR+QjIxget9J4JhT79jNrR/tSgLrD/5OYMN9ywJ/6YbhaGw==', N'378ab4dc-6f18-41ed-9736-c004ed692b82', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'602c8d70-13e4-425b-820a-02da2088c448', N'guest@vidly.com', 0, N'AHyo54wlB6NKCGSUsfez7SCv/iEt0yjRjm4hTosuIRunZ3LJ3bW7OkWUR18OdGHeJg==', N'3ee89a52-0875-462e-bfb9-69b0ca9aad74', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'e8191758-d347-4c0d-a232-faa4711eb35a', N'CanManageMovies')                    
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'393085c7-413a-47c3-9445-6dbf46c8cfd4', N'e8191758-d347-4c0d-a232-faa4711eb35a')


                ");
        }

        public override void Down()
        {
        }
    }
}
