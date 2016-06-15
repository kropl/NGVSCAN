namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedSomePropertiesFromROCMeasurePoint : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ROC809MeasurePoints", "Type");
            DropColumn("dbo.ROC809MeasurePoints", "LogicalNumber");
            DropColumn("dbo.ROC809MeasurePoints", "ParameterNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ROC809MeasurePoints", "ParameterNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ROC809MeasurePoints", "LogicalNumber", c => c.Int(nullable: false));
            AddColumn("dbo.ROC809MeasurePoints", "Type", c => c.Int(nullable: false));
        }
    }
}
