namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedROCAlarmTypesEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ROC809AlarmsCodes",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.ROC809AlarmsTypes",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Code);
            
            CreateTable(
                "dbo.ROC809EventsCodes",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ROC809EventsCodes");
            DropTable("dbo.ROC809AlarmsTypes");
            DropTable("dbo.ROC809AlarmsCodes");
        }
    }
}
