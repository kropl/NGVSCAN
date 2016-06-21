namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedROCAlarmDataEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ROC809AlarmData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        Type = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        SRBX = c.Boolean(nullable: false),
                        Condition = c.Boolean(nullable: false),
                        T = c.Int(),
                        L = c.Int(),
                        P = c.Int(),
                        Value = c.String(nullable: false, maxLength: 10),
                        Description = c.String(nullable: false, maxLength: 20),
                        Code = c.Int(),
                        FST = c.Int(),
                        ROC809MeasurePointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROC809MeasurePoints", t => t.ROC809MeasurePointId)
                .Index(t => t.ROC809MeasurePointId);
            
            AddColumn("dbo.FloutecSensorsTypes", "Description", c => c.String(nullable: false, maxLength: 400));
            AlterColumn("dbo.FloutecParamsTypes", "Description", c => c.String(nullable: false, maxLength: 400));
            DropColumn("dbo.FloutecSensorsTypes", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FloutecSensorsTypes", "Name", c => c.String(nullable: false, maxLength: 25));
            DropForeignKey("dbo.ROC809AlarmData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints");
            DropIndex("dbo.ROC809AlarmData", new[] { "ROC809MeasurePointId" });
            AlterColumn("dbo.FloutecParamsTypes", "Description", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.FloutecSensorsTypes", "Description");
            DropTable("dbo.ROC809AlarmData");
        }
    }
}
