namespace GolfFinder_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rating", "CourseID", "dbo.Course");
            DropIndex("dbo.Rating", new[] { "CourseID" });
            RenameColumn(table: "dbo.Rating", name: "CourseID", newName: "Course_CourseID");
            AlterColumn("dbo.Rating", "Course_CourseID", c => c.Int());
            AlterColumn("dbo.Rating", "Cleanliness", c => c.Int(nullable: false));
            AlterColumn("dbo.Rating", "Layout", c => c.Int(nullable: false));
            AlterColumn("dbo.Rating", "Dificulty", c => c.Int(nullable: false));
            AlterColumn("dbo.Rating", "Amenities", c => c.Int(nullable: false));
            CreateIndex("dbo.Rating", "Course_CourseID");
            AddForeignKey("dbo.Rating", "Course_CourseID", "dbo.Course", "CourseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rating", "Course_CourseID", "dbo.Course");
            DropIndex("dbo.Rating", new[] { "Course_CourseID" });
            AlterColumn("dbo.Rating", "Amenities", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Rating", "Dificulty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Rating", "Layout", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Rating", "Cleanliness", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Rating", "Course_CourseID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Rating", name: "Course_CourseID", newName: "CourseID");
            CreateIndex("dbo.Rating", "CourseID");
            AddForeignKey("dbo.Rating", "CourseID", "dbo.Course", "CourseID", cascadeDelete: true);
        }
    }
}
