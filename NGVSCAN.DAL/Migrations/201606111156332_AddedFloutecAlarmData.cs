namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFloutecAlarmData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloutecAlarmData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        N_FLONIT = c.Int(nullable: false),
                        DAT = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        T_AVAR = c.Int(nullable: false),
                        T_PARAM = c.Int(nullable: false),
                        VAL = c.Double(nullable: false),
                        FloutecMeasureLineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FloutecMeasureLines", t => t.FloutecMeasureLineId)
                .Index(t => t.FloutecMeasureLineId);
            
            CreateTable(
                "dbo.FloutecParamsTypes",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Param = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FloutecAlarmData", "FloutecMeasureLineId", "dbo.FloutecMeasureLines");
            DropIndex("dbo.FloutecAlarmData", new[] { "FloutecMeasureLineId" });
            DropTable("dbo.FloutecParamsTypes");
            DropTable("dbo.FloutecAlarmData");
        }
    }
}
