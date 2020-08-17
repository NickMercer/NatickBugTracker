namespace BugTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1a1a87cb-3cb2-44cb-9772-7e9919cd2741', N'Admin@Natick.co', 0, N'AGnUDKolSo+EVc2pH60sD9+AJJllmbuqCdeo0n4dyrs/T8Trz8irUyPT1hktxjTBRw==', N'43c49dfb-12ca-4696-bc9d-45a26b9140b4', NULL, 0, 0, NULL, 1, 0, N'TestAdmin')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1abd4bdb-04c5-43cc-ad0c-97c4576bc242', N'Guest@Natick.co', 0, N'AEerEg6gcOFQmlmvj+A5c+cSqjrLF37OiMIM47VyVh6FgxrurvkfHYTVfRJEOahSxg==', N'617faf61-5de2-4173-97db-595915443b02', NULL, 0, 0, NULL, 1, 0, N'TestGuest')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b9e2a7a4-cc93-4683-bc0a-fbc2a60b84f5', N'ProjectLead@Natick.co', 0, N'AP7fKq0x2DawBQCtAld/zQXIsqQHul63h6ihx9jF977ktigJrfQO8Hzh4gbhwsBn2g==', N'fe807502-c6ef-4d91-bf39-c2a13cfef570', NULL, 0, 0, NULL, 1, 0, N'TestProjectLead')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bdfd64ac-ec39-4bc8-9811-694822572b2a', N'nickmercerdev@gmail.com', 0, N'ABNOtRLY4MqyfDZEN6Jnf4hcvvfzwOnNepl6zNdREpKJbjkGjmjXwj/md6burSJFfQ==', N'b25ff39c-31ff-4a0e-aa72-5ce602105839', NULL, 0, 0, NULL, 1, 0, N'Nick')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c01e85a6-9be2-4e2c-9749-dcc8b4812cf5', N'Developer@Natick.co', 0, N'AG8y1T9dEDdqEIFFuFhKd+L8cfWtfJ7lMcUMstNgwbhgvP1E5yaWsrLxJ2ejwt/fhw==', N'dd716c0e-4f21-48c6-aa7e-560e7b96d22e', NULL, 0, 0, NULL, 1, 0, N'TestDeveloper')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'ad2906c3-6918-4e6e-9bfb-ab413c977d2e', N'Admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cba8e266-01c0-40c2-b469-d7ce6d66ddc6', N'Developer')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'a7fc44a0-6387-4c1e-aefd-84412fe4a357', N'Guest')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'65b07f10-795a-402c-918f-254f90aaec18', N'ProjectLead')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b9e2a7a4-cc93-4683-bc0a-fbc2a60b84f5', N'65b07f10-795a-402c-918f-254f90aaec18')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1abd4bdb-04c5-43cc-ad0c-97c4576bc242', N'a7fc44a0-6387-4c1e-aefd-84412fe4a357')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1a1a87cb-3cb2-44cb-9772-7e9919cd2741', N'ad2906c3-6918-4e6e-9bfb-ab413c977d2e')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bdfd64ac-ec39-4bc8-9811-694822572b2a', N'ad2906c3-6918-4e6e-9bfb-ab413c977d2e')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c01e85a6-9be2-4e2c-9749-dcc8b4812cf5', N'cba8e266-01c0-40c2-b469-d7ce6d66ddc6')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
