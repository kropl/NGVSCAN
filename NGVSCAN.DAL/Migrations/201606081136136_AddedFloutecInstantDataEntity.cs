namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFloutecInstantDataEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloutecInstantData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        N_FLONIT = c.Int(nullable: false),
                        DAT = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        QHOUR = c.Double(nullable: false),
                        PQHOUR = c.Double(nullable: false),
                        CURRSPEND = c.Double(nullable: false),
                        DAYSPEND = c.Double(nullable: false),
                        YESTSPEND = c.Double(nullable: false),
                        MONTHSPEND = c.Double(nullable: false),
                        LASTMONTHSPEND = c.Double(nullable: false),
                        ALLSPEND = c.Double(nullable: false),
                        ALARMSY = c.Double(nullable: false),
                        ALARMRY = c.Double(nullable: false),
                        PALARMSY = c.Double(nullable: false),
                        PALARMRY = c.Double(nullable: false),
                        PERPRES = c.Double(nullable: false),
                        PP = c.String(nullable: false, maxLength: 1),
                        STPRES = c.Double(nullable: false),
                        PD = c.String(nullable: false, maxLength: 1),
                        ABSP = c.Double(nullable: false),
                        TEMP = c.Double(nullable: false),
                        PT = c.String(nullable: false, maxLength: 1),
                        GASVIZ = c.Double(nullable: false),
                        SQROOT = c.Double(nullable: false),
                        GAZPLOTNRU = c.Double(nullable: false),
                        GAZPLOTNNU = c.Double(nullable: false),
                        DLITAS = c.Int(nullable: false),
                        DLITBAS = c.Int(nullable: false),
                        DLITMAS = c.Int(nullable: false),
                        PDLITAS = c.Int(nullable: false),
                        PDLITBAS = c.Int(nullable: false),
                        PDLITMAS = c.Int(nullable: false),
                        FloutecMeasureLineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FloutecMeasureLines", t => t.FloutecMeasureLineId)
                .Index(t => t.FloutecMeasureLineId);
            
            AddColumn("dbo.FloutecMeasureLines", "InstantDataScanPeriod", c => c.Int(nullable: false));
            AddColumn("dbo.FloutecMeasureLines", "DateInstantDataLastScanned", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FloutecInstantData", "FloutecMeasureLineId", "dbo.FloutecMeasureLines");
            DropIndex("dbo.FloutecInstantData", new[] { "FloutecMeasureLineId" });
            DropColumn("dbo.FloutecMeasureLines", "DateInstantDataLastScanned");
            DropColumn("dbo.FloutecMeasureLines", "InstantDataScanPeriod");
            DropTable("dbo.FloutecInstantData");
        }
    }
}
