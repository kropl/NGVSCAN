namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFloutecSensorsTypes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloutecSensorsTypes",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FloutecSensorsTypes");
        }
    }
}
