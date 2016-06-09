namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFloutecHourlyDataStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloutecHourlyDataStatus",
                c => new
                    {
                        FloutecHourlyDataId = c.Int(nullable: false),
                        DAT = c.Boolean(nullable: false),
                        DAT_END = c.Boolean(nullable: false),
                        RASX = c.Boolean(nullable: false),
                        DAVL = c.Boolean(nullable: false),
                        PD = c.Boolean(nullable: false),
                        TEMP = c.Boolean(nullable: false),
                        PT = c.Boolean(nullable: false),
                        PEREP = c.Boolean(nullable: false),
                        PP = c.Boolean(nullable: false),
                        PLOTN = c.Boolean(nullable: false),
                        PL = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FloutecHourlyDataId)
                .ForeignKey("dbo.FloutecHourlyData", t => t.FloutecHourlyDataId)
                .Index(t => t.FloutecHourlyDataId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FloutecHourlyDataStatus", "FloutecHourlyDataId", "dbo.FloutecHourlyData");
            DropIndex("dbo.FloutecHourlyDataStatus", new[] { "FloutecHourlyDataId" });
            DropTable("dbo.FloutecHourlyDataStatus");
        }
    }
}
