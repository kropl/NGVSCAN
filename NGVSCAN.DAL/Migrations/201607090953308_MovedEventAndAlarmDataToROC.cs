namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MovedEventAndAlarmDataToROC : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ROC809AlarmData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints");
            DropForeignKey("dbo.ROC809EventData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints");
            DropIndex("dbo.ROC809AlarmData", new[] { "ROC809MeasurePointId" });
            DropIndex("dbo.ROC809EventData", new[] { "ROC809MeasurePointId" });
            AddColumn("dbo.ROC809AlarmData", "ROC809Id", c => c.Int(nullable: false));
            AddColumn("dbo.ROC809EventData", "ROC809Id", c => c.Int(nullable: false));
            CreateIndex("dbo.ROC809AlarmData", "ROC809Id");
            CreateIndex("dbo.ROC809EventData", "ROC809Id");
            AddForeignKey("dbo.ROC809AlarmData", "ROC809Id", "dbo.ROC809s", "Id");
            AddForeignKey("dbo.ROC809EventData", "ROC809Id", "dbo.ROC809s", "Id");
            DropColumn("dbo.ROC809AlarmData", "ROC809MeasurePointId");
            DropColumn("dbo.ROC809EventData", "ROC809MeasurePointId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ROC809EventData", "ROC809MeasurePointId", c => c.Int(nullable: false));
            AddColumn("dbo.ROC809AlarmData", "ROC809MeasurePointId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ROC809EventData", "ROC809Id", "dbo.ROC809s");
            DropForeignKey("dbo.ROC809AlarmData", "ROC809Id", "dbo.ROC809s");
            DropIndex("dbo.ROC809EventData", new[] { "ROC809Id" });
            DropIndex("dbo.ROC809AlarmData", new[] { "ROC809Id" });
            DropColumn("dbo.ROC809EventData", "ROC809Id");
            DropColumn("dbo.ROC809AlarmData", "ROC809Id");
            CreateIndex("dbo.ROC809EventData", "ROC809MeasurePointId");
            CreateIndex("dbo.ROC809AlarmData", "ROC809MeasurePointId");
            AddForeignKey("dbo.ROC809EventData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints", "Id");
            AddForeignKey("dbo.ROC809AlarmData", "ROC809MeasurePointId", "dbo.ROC809MeasurePoints", "Id");
        }
    }
}
