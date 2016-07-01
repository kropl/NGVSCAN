namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedOperatorIdToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ROC809EventData", "OperatorId", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ROC809EventData", "OperatorId", c => c.Int());
        }
    }
}
