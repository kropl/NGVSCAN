namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAlarmsTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloutecAlarmsTypes",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 400),
                        Description_45 = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Code);
            
            AddColumn("dbo.FloutecIdentData", "TYPDAN", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FloutecIdentData", "TYPDAN");
            DropTable("dbo.FloutecAlarmsTypes");
        }
    }
}
