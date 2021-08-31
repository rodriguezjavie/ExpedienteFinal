namespace ExpedienteIDON.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'23c82d8f-ad6b-48ae-89a2-c78ca1a1da88', N'doctor@gooddata.com.mx', 1, N'AHaUMybp8pkOzH7wME9eX6ouw1QOxNot2NQZuKAxx29Ow1t6snCGdv8AHvqJXqnWZg==', N'738159a7-03aa-4e56-b28d-1f7d11cff8f8', NULL, 0, 0, NULL, 1, 0, N'doctor@gooddata.com.mx')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3b2cb33d-d1a5-4aa3-a99a-4c2931711331', N'rodriguezjavie@gmail.com', 1, N'AIosEM7tA4rYeGPwxq3r8k2rTkTdcQnhCgXyM3ADfNDbJIu5C5zPxc4M21wxWtDVRg==', N'68703319-2708-4fc7-8789-ccfdb26afb5f', NULL, 0, 0, NULL, 1, 0, N'rodriguezjavie@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e82bad99-e5df-412c-b5d0-f9909061ff8f', N'admin@gooddata.com.mx', 1, N'AKl/sNnG5CZsj/jGrYCxbrg6zt6/yqy0rUhHunh27fSFEIqTUlRWI4zQBpdJXYLabA==', N'0efc2145-29c1-451c-b8f1-e33d30f716c2', NULL, 0, 0, NULL, 1, 0, N'admin@gooddata.com.mx')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'07ef2845-4904-4dc9-b24b-b01a98b77f56', N'Administrador', N'ApplicationRole')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'463e2ab5-c38e-4d7f-9c85-28bb643d1dbc', N'Deshabilitado', N'ApplicationRole')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [Discriminator]) VALUES (N'8d07538f-4220-465e-b9b5-b21c16b27870', N'Doctor', N'ApplicationRole')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3b2cb33d-d1a5-4aa3-a99a-4c2931711331', N'07ef2845-4904-4dc9-b24b-b01a98b77f56')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e82bad99-e5df-412c-b5d0-f9909061ff8f', N'07ef2845-4904-4dc9-b24b-b01a98b77f56')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'23c82d8f-ad6b-48ae-89a2-c78ca1a1da88', N'8d07538f-4220-465e-b9b5-b21c16b27870')

");
        }
        
        public override void Down()
        {
        }
    }
}
