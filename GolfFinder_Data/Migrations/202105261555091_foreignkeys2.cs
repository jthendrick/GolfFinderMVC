namespace GolfFinder_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeys2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Score", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Score", "CreatedUtc");
        }
    }
}
