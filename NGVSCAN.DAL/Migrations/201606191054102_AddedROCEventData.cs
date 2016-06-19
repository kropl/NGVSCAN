namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedROCEventData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ROC809EventData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        Type = c.Int(nullable: false),
                        Time = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        OperatorId = c.Int(),
                        T = c.Int(),
                        L = c.Int(),
                        P = c.Int(),
                        Value = c.String(nullable: false, maxLength: 10),
                        NewValue = c.String(nullable: false, maxLength: 10),
                        OldValue = c.String(nullable: false, maxLength: 10),
                        RawValue = c.String(nullable: false, maxLength: 10),
                        CalibratedValue = c.String(nullable: false, maxLength: 10),
                        Description = c.String(nullable: false, maxLength: 20),
                        Code = c.Int(),
                        FST = c.Int(),
                        ROC809MeasurePointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ROC809MeasurePoints", t => t.ROC809MeasurePointId)
                .Index(t => t.ROC809MeasurePointId);
            
            CreateTable(
                "dbo.ROC809EventsTypes",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Code);
            
            AlterColumn("dbo.ROC809DailyData", "DatePeriod", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ROC809MinuteData", "DatePeriod", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.ROC809PeriodicData", "DatePeriod", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ROC809EventData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints");
            DropIndex("dbo.ROC809EventData", new[] { "ROC809MeasurePointId" });
            AlterColumn("dbo.ROC809PeriodicData", "DatePeriod", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ROC809MinuteData", "DatePeriod", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ROC809DailyData", "DatePeriod", c => c.DateTime(nullable: false));
            DropTable("dbo.ROC809EventsTypes");
            DropTable("dbo.ROC809EventData");
        }
    }
}
