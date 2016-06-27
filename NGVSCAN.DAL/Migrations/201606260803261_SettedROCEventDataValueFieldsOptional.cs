namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettedROCEventDataValueFieldsOptional : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ROC809EventData", "Value", c => c.String(maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "NewValue", c => c.String(maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "OldValue", c => c.String(maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "RawValue", c => c.String(maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "CalibratedValue", c => c.String(maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "Description", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ROC809EventData", "Description", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.ROC809EventData", "CalibratedValue", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "RawValue", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "OldValue", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "NewValue", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.ROC809EventData", "Value", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
