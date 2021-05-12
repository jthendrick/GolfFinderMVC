namespace GolfFinder_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "OwnerID", c => c.Guid(nullable: false));
            AlterColumn("dbo.Course", "CourseName", c => c.String());
            AlterColumn("dbo.Course", "CourseAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Course", "CourseAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Course", "CourseName", c => c.String(nullable: false));
            DropColumn("dbo.Course", "OwnerID");
        }
    }
}
