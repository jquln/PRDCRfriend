namespace PRDCRfriend.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artist",
                c => new
                    {
                        ArtistId = c.Int(nullable: false, identity: true),
                        Session = c.String(),
                        OwnerId = c.Guid(nullable: false),
                        LastName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        ProjectTitle = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Session_SessionId = c.Int(),
                    })
                .PrimaryKey(t => t.ArtistId)
                .ForeignKey("dbo.Session", t => t.Session_SessionId)
                .Index(t => t.Session_SessionId);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        SessionId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ProjectTitle = c.String(nullable: false),
                        ArtistFirstName = c.String(),
                        ArtistLastName = c.String(),
                        Time = c.DateTime(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        ProducerId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        Session_SessionId = c.Int(),
                        Artist_ArtistId = c.Int(),
                    })
                .PrimaryKey(t => t.SessionId)
                .ForeignKey("dbo.Artist", t => t.ArtistId, cascadeDelete: true)
                .ForeignKey("dbo.Producer", t => t.ProducerId, cascadeDelete: true)
                .ForeignKey("dbo.Session", t => t.Session_SessionId)
                .ForeignKey("dbo.Artist", t => t.Artist_ArtistId)
                .Index(t => t.ProducerId)
                .Index(t => t.ArtistId)
                .Index(t => t.Session_SessionId)
                .Index(t => t.Artist_ArtistId);
            
            CreateTable(
                "dbo.Producer",
                c => new
                    {
                        ProducerId = c.Int(nullable: false, identity: true),
                        Session = c.String(),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        OwnerId = c.Guid(nullable: false),
                        PlannerId = c.String(),
                    })
                .PrimaryKey(t => t.ProducerId);
            
            CreateTable(
                "dbo.ProjectPlanner",
                c => new
                    {
                        PlannerId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ArtistName = c.String(),
                        Content = c.String(nullable: false),
                        ProducerId = c.Int(nullable: false),
                        SessionId = c.Int(nullable: false),
                        ProjectTitle = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PlannerId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Session", "Artist_ArtistId", "dbo.Artist");
            DropForeignKey("dbo.Session", "Session_SessionId", "dbo.Session");
            DropForeignKey("dbo.Session", "ProducerId", "dbo.Producer");
            DropForeignKey("dbo.Artist", "Session_SessionId", "dbo.Session");
            DropForeignKey("dbo.Session", "ArtistId", "dbo.Artist");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Session", new[] { "Artist_ArtistId" });
            DropIndex("dbo.Session", new[] { "Session_SessionId" });
            DropIndex("dbo.Session", new[] { "ArtistId" });
            DropIndex("dbo.Session", new[] { "ProducerId" });
            DropIndex("dbo.Artist", new[] { "Session_SessionId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.ProjectPlanner");
            DropTable("dbo.Producer");
            DropTable("dbo.Session");
            DropTable("dbo.Artist");
        }
    }
}
