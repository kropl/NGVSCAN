namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCounterFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FloutecInstantData", "PRITUPL", c => c.Double(nullable: false, defaultValue: 0.0));
            AddColumn("dbo.FloutecInstantData", "REZ", c => c.Double(nullable: false, defaultValue: 0.0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FloutecInstantData", "REZ");
            DropColumn("dbo.FloutecInstantData", "PRITUPL");
        }
    }
}
