namespace GolfFinder_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourthmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        CourseID = c.Int(nullable: false),
                        Cleanliness = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Layout = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dificulty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Amenities = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "CourseID", "dbo.Course");
            DropIndex("dbo.Rating", new[] { "CourseID" });
            DropTable("dbo.Rating");
        }
    }
}
