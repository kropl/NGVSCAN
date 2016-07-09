namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSCHETToFloutecIdentData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FloutecIdentData", "SCHET", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FloutecIdentData", "SCHET");
        }
    }
}
