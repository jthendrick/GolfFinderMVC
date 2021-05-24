namespace GolfFinder_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedViews : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Score");
            DropColumn("dbo.Score", "ScoreSheetID");
            AddColumn("dbo.Score", "ScoreID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Score", "ScoreID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Score");
            AddColumn("dbo.Score", "ScoreSheetID", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Score", "ScoreID");
            AddPrimaryKey("dbo.Score", "ScoreSheetID");
        }
    }
}
