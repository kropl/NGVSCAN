namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedROCDataEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ROC809DailyData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        DatePeriod = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        ROC809MeasurePointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROC809MeasurePoints", t => t.ROC809MeasurePointId)
                .Index(t => t.ROC809MeasurePointId);
            
            CreateTable(
                "dbo.ROC809MinuteData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        DatePeriod = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        ROC809MeasurePointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROC809MeasurePoints", t => t.ROC809MeasurePointId)
                .Index(t => t.ROC809MeasurePointId);
            
            CreateTable(
                "dbo.ROC809PeriodicData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        DatePeriod = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                        ROC809MeasurePointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROC809MeasurePoints", t => t.ROC809MeasurePointId)
                .Index(t => t.ROC809MeasurePointId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ROC809PeriodicData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints");
            DropForeignKey("dbo.ROC809MinuteData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints");
            DropForeignKey("dbo.ROC809DailyData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints");
            DropIndex("dbo.ROC809PeriodicData", new[] { "ROC809MeasurePointId" });
            DropIndex("dbo.ROC809MinuteData", new[] { "ROC809MeasurePointId" });
            DropIndex("dbo.ROC809DailyData", new[] { "ROC809MeasurePointId" });
            DropTable("dbo.ROC809PeriodicData");
            DropTable("dbo.ROC809MinuteData");
            DropTable("dbo.ROC809DailyData");
        }
    }
}
