namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDataScanPeriodsForROCs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ROC809MeasurePoints", "MinuteDataScanPeriod", c => c.Int(nullable: false));
            AddColumn("dbo.ROC809MeasurePoints", "DateMinuteDataLastScanned", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.ROC809MeasurePoints", "PeriodicDataScanPeriod", c => c.Int(nullable: false));
            AddColumn("dbo.ROC809MeasurePoints", "DatePeriodicDataLastScanned", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AddColumn("dbo.ROC809MeasurePoints", "DailyDataScanPeriod", c => c.Int(nullable: false));
            AddColumn("dbo.ROC809MeasurePoints", "DateDailyDataLastScanned", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.FloutecMeasureLines", "DateInstantDataLastScanned", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FloutecMeasureLines", "DateInstantDataLastScanned", c => c.DateTime());
            DropColumn("dbo.ROC809MeasurePoints", "DateDailyDataLastScanned");
            DropColumn("dbo.ROC809MeasurePoints", "DailyDataScanPeriod");
            DropColumn("dbo.ROC809MeasurePoints", "DatePeriodicDataLastScanned");
            DropColumn("dbo.ROC809MeasurePoints", "PeriodicDataScanPeriod");
            DropColumn("dbo.ROC809MeasurePoints", "DateMinuteDataLastScanned");
            DropColumn("dbo.ROC809MeasurePoints", "MinuteDataScanPeriod");
        }
    }
}
