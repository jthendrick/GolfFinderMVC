namespace GolfFinder_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        CourseName = c.String(),
                        CourseAddress = c.String(),
                        BeginnerFriendly = c.Boolean(nullable: false),
                        AlcoholFriendly = c.Boolean(nullable: false),
                        NineHoleCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EighteenHoleCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Cleanliness = c.Int(nullable: false),
                        Layout = c.Int(nullable: false),
                        Dificulty = c.Int(nullable: false),
                        Amenities = c.Int(nullable: false),
                        Course_CourseID = c.Int(),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Course", t => t.Course_CourseID)
                .Index(t => t.Course_CourseID);
            
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
                "dbo.Score",
                c => new
                    {
                        ScoreSheetID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Hole1 = c.Int(nullable: false),
                        ParHole1 = c.Int(nullable: false),
                        Hole2 = c.Int(nullable: false),
                        ParHole2 = c.Int(nullable: false),
                        Hole3 = c.Int(nullable: false),
                        ParHole3 = c.Int(nullable: false),
                        Hole4 = c.Int(nullable: false),
                        ParHole4 = c.Int(nullable: false),
                        Hole5 = c.Int(nullable: false),
                        ParHole5 = c.Int(nullable: false),
                        Hole6 = c.Int(nullable: false),
                        ParHole6 = c.Int(nullable: false),
                        Hole7 = c.Int(nullable: false),
                        ParHole7 = c.Int(nullable: false),
                        Hole8 = c.Int(nullable: false),
                        ParHole8 = c.Int(nullable: false),
                        Hole9 = c.Int(nullable: false),
                        ParHole9 = c.Int(nullable: false),
                        Hole10 = c.Int(nullable: false),
                        ParHole10 = c.Int(nullable: false),
                        Hole11 = c.Int(nullable: false),
                        ParHole11 = c.Int(nullable: false),
                        Hole12 = c.Int(nullable: false),
                        ParHole12 = c.Int(nullable: false),
                        Hole13 = c.Int(nullable: false),
                        ParHole13 = c.Int(nullable: false),
                        Hole14 = c.Int(nullable: false),
                        ParHole14 = c.Int(nullable: false),
                        Hole15 = c.Int(nullable: false),
                        ParHole15 = c.Int(nullable: false),
                        Hole16 = c.Int(nullable: false),
                        ParHole16 = c.Int(nullable: false),
                        Hole17 = c.Int(nullable: false),
                        ParHole17 = c.Int(nullable: false),
                        Hole18 = c.Int(nullable: false),
                        ParHole18 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ScoreSheetID);
            
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
            DropForeignKey("dbo.Rating", "Course_CourseID", "dbo.Course");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Rating", new[] { "Course_CourseID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Score");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Rating");
            DropTable("dbo.Course");
        }
    }
}
