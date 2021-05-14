namespace GolfFinder_Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scorefunction : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Score");
        }
    }
}
