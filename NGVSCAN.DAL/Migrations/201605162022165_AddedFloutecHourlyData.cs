namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFloutecHourlyData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeasureLines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 200),
                        EstimatorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estimators", t => t.EstimatorId, cascadeDelete: true)
                .Index(t => t.EstimatorId);
            
            CreateTable(
                "dbo.FloutecHourlyDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        N_FLONIT = c.Int(nullable: false),
                        DAT = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DAT_END = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        RASX = c.Double(nullable: false),
                        DAVL = c.Double(nullable: false),
                        PD = c.String(nullable: false, maxLength: 1),
                        TEMP = c.Double(nullable: false),
                        PT = c.String(nullable: false, maxLength: 1),
                        PEREP = c.Double(nullable: false),
                        PP = c.String(nullable: false, maxLength: 1),
                        PLOTN = c.Double(nullable: false),
                        PL = c.String(nullable: false, maxLength: 1),
                        FloutecMeasureLineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FloutecMeasureLines", t => t.FloutecMeasureLineId)
                .Index(t => t.FloutecMeasureLineId);
            
            CreateTable(
                "dbo.FloutecMeasureLines",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeasureLines", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FloutecMeasureLines", "Id", "dbo.MeasureLines");
            DropForeignKey("dbo.MeasureLines", "EstimatorId", "dbo.Estimators");
            DropForeignKey("dbo.FloutecHourlyDatas", "FloutecMeasureLineId", "dbo.FloutecMeasureLines");
            DropIndex("dbo.FloutecMeasureLines", new[] { "Id" });
            DropIndex("dbo.FloutecHourlyDatas", new[] { "FloutecMeasureLineId" });
            DropIndex("dbo.MeasureLines", new[] { "EstimatorId" });
            DropTable("dbo.FloutecMeasureLines");
            DropTable("dbo.FloutecHourlyDatas");
            DropTable("dbo.MeasureLines");
        }
    }
}
