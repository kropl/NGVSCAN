namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedPluralFromFloutecDataTables : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FloutecHourlyDatas", newName: "FloutecHourlyData");
            RenameTable(name: "dbo.FloutecIdentDatas", newName: "FloutecIdentData");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.FloutecIdentData", newName: "FloutecIdentDatas");
            RenameTable(name: "dbo.FloutecHourlyData", newName: "FloutecHourlyDatas");
        }
    }
}
