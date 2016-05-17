namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFloutecIdentData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloutecIdentDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        N_FLONIT = c.Int(nullable: false),
                        KONTRH = c.Time(nullable: false, precision: 7),
                        NO2 = c.Double(nullable: false),
                        OTBOR = c.Int(nullable: false),
                        ACP = c.Double(nullable: false),
                        ACS = c.Double(nullable: false),
                        SHER = c.Double(nullable: false),
                        VERXP = c.Double(nullable: false),
                        PLOTN = c.Double(nullable: false),
                        DTRUB = c.Double(nullable: false),
                        OTSECH = c.Double(nullable: false),
                        BCP = c.Double(nullable: false),
                        BCS = c.Double(nullable: false),
                        VERXDP = c.Double(nullable: false),
                        NIZT = c.Double(nullable: false),
                        CO2 = c.Double(nullable: false),
                        DSU = c.Double(nullable: false),
                        CCP = c.Double(nullable: false),
                        CCS = c.Double(nullable: false),
                        NIZP = c.Double(nullable: false),
                        VERXT = c.Double(nullable: false),
                        KONDENS = c.Int(nullable: false),
                        KALIBSCH = c.Double(nullable: false),
                        MINRSCH = c.Double(nullable: false),
                        MAXRSCH = c.Double(nullable: false),
                        FloutecMeasureLineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FloutecMeasureLines", t => t.FloutecMeasureLineId)
                .Index(t => t.FloutecMeasureLineId);
            
            AddColumn("dbo.FloutecMeasureLines", "SensorType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FloutecIdentDatas", "FloutecMeasureLineId", "dbo.FloutecMeasureLines");
            DropIndex("dbo.FloutecIdentDatas", new[] { "FloutecMeasureLineId" });
            DropColumn("dbo.FloutecMeasureLines", "SensorType");
            DropTable("dbo.FloutecIdentDatas");
        }
    }
}
