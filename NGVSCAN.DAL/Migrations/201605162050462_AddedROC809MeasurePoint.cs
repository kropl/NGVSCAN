namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedROC809MeasurePoint : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ROC809MeasurePoints",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        LogicalNumber = c.Int(nullable: false),
                        ParameterNumber = c.Int(nullable: false),
                        HistSegment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeasureLines", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ROC809MeasurePoints", "Id", "dbo.MeasureLines");
            DropIndex("dbo.ROC809MeasurePoints", new[] { "Id" });
            DropTable("dbo.ROC809MeasurePoints");
        }
    }
}
