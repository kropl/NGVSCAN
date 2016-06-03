namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedScanPeriodForHourlyData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FloutecMeasureLines", "HourlyDataScanPeriod", c => c.Int(nullable: false));
            AddColumn("dbo.FloutecMeasureLines", "DateHourlyDataLastScanned", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FloutecMeasureLines", "DateHourlyDataLastScanned");
            DropColumn("dbo.FloutecMeasureLines", "HourlyDataScanPeriod");
        }
    }
}
