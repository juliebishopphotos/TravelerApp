namespace TravelerApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eat",
                c => new
                    {
                        EatId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EatId);
            
            CreateTable(
                "dbo.TripEat",
                c => new
                    {
                        TripId = c.Int(nullable: false),
                        EatId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TripId, t.EatId })
                .ForeignKey("dbo.Eat", t => t.EatId, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId)
                .Index(t => t.EatId);
            
            CreateTable(
                "dbo.Trip",
                c => new
                    {
                        TripId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TripId);
            
            CreateTable(
                "dbo.TripSee",
                c => new
                    {
                        TripId = c.Int(nullable: false),
                        SeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TripId, t.SeeId })
                .ForeignKey("dbo.See", t => t.SeeId, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId)
                .Index(t => t.SeeId);
            
            CreateTable(
                "dbo.See",
                c => new
                    {
                        SeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SeeId);
            
            CreateTable(
                "dbo.TripStay",
                c => new
                    {
                        TripId = c.Int(nullable: false),
                        StayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TripId, t.StayId })
                .ForeignKey("dbo.Stay", t => t.StayId, cascadeDelete: true)
                .ForeignKey("dbo.Trip", t => t.TripId, cascadeDelete: true)
                .Index(t => t.TripId)
                .Index(t => t.StayId);
            
            CreateTable(
                "dbo.Stay",
                c => new
                    {
                        StayId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        TypeOfLodging = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StayId);
            
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
            DropForeignKey("dbo.TripEat", "TripId", "dbo.Trip");
            DropForeignKey("dbo.TripStay", "TripId", "dbo.Trip");
            DropForeignKey("dbo.TripStay", "StayId", "dbo.Stay");
            DropForeignKey("dbo.TripSee", "TripId", "dbo.Trip");
            DropForeignKey("dbo.TripSee", "SeeId", "dbo.See");
            DropForeignKey("dbo.TripEat", "EatId", "dbo.Eat");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.TripStay", new[] { "StayId" });
            DropIndex("dbo.TripStay", new[] { "TripId" });
            DropIndex("dbo.TripSee", new[] { "SeeId" });
            DropIndex("dbo.TripSee", new[] { "TripId" });
            DropIndex("dbo.TripEat", new[] { "EatId" });
            DropIndex("dbo.TripEat", new[] { "TripId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Stay");
            DropTable("dbo.TripStay");
            DropTable("dbo.See");
            DropTable("dbo.TripSee");
            DropTable("dbo.Trip");
            DropTable("dbo.TripEat");
            DropTable("dbo.Eat");
        }
    }
}
