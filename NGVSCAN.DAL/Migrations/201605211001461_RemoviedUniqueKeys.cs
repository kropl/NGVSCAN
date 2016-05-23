namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoviedUniqueKeys : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Estimators", "IX_Floutec");
            DropIndex("dbo.Fields", "IX_Field");
            DropIndex("dbo.MeasureLines", "IX_FloutecLine");
            DropIndex("dbo.FloutecMeasureLines", "IX_FloutecLine");
            DropIndex("dbo.Floutecs", "IX_Floutec");
            CreateIndex("dbo.Estimators", "FieldId");
            CreateIndex("dbo.MeasureLines", "EstimatorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.MeasureLines", new[] { "EstimatorId" });
            DropIndex("dbo.Estimators", new[] { "FieldId" });
            CreateIndex("dbo.Floutecs", "Address", unique: true, name: "IX_Floutec");
            CreateIndex("dbo.FloutecMeasureLines", "Number", unique: true, name: "IX_FloutecLine");
            CreateIndex("dbo.MeasureLines", "EstimatorId", unique: true, name: "IX_FloutecLine");
            CreateIndex("dbo.Fields", "Name", unique: true, name: "IX_Field");
            CreateIndex("dbo.Estimators", new[] { "FieldId", "Name" }, unique: true, name: "IX_Floutec");
        }
    }
}
