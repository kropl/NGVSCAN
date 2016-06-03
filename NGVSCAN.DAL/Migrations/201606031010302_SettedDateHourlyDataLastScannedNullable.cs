namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettedDateHourlyDataLastScannedNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FloutecMeasureLines", "DateHourlyDataLastScanned", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FloutecMeasureLines", "DateHourlyDataLastScanned", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
