namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIndexesToEntities : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Estimators", new[] { "FieldId" });
            DropIndex("dbo.MeasureLines", new[] { "EstimatorId" });
            CreateIndex("dbo.Estimators", new[] { "FieldId", "Name" }, unique: true, name: "IX_Floutec");
            CreateIndex("dbo.Fields", "Name", unique: true, name: "IX_Field");
            CreateIndex("dbo.MeasureLines", "EstimatorId", unique: true, name: "IX_FloutecLine");
            CreateIndex("dbo.FloutecMeasureLines", "Number", unique: true, name: "IX_FloutecLine");
            CreateIndex("dbo.Floutecs", "Address", unique: true, name: "IX_Floutec");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Floutecs", "IX_Floutec");
            DropIndex("dbo.FloutecMeasureLines", "IX_FloutecLine");
            DropIndex("dbo.MeasureLines", "IX_FloutecLine");
            DropIndex("dbo.Fields", "IX_Field");
            DropIndex("dbo.Estimators", "IX_Floutec");
            CreateIndex("dbo.MeasureLines", "EstimatorId");
            CreateIndex("dbo.Estimators", "FieldId");
        }
    }
}
