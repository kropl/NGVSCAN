namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFloutecInterData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FloutecInterData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        N_FLONIT = c.Int(nullable: false),
                        DAT = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CH_PAR = c.Int(nullable: false),
                        T_PARAM = c.Int(),
                        VAL_OLD = c.String(nullable: false),
                        VAL_NEW = c.String(nullable: false),
                        FloutecMeasureLineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FloutecMeasureLines", t => t.FloutecMeasureLineId)
                .Index(t => t.FloutecMeasureLineId);
            
            CreateTable(
                "dbo.FloutecIntersTypes",
                c => new
                    {
                        Code = c.Int(nullable: false),
                        Description = c.String(nullable: false, maxLength: 400),
                        Description_45 = c.String(nullable: false, maxLength: 400),
                    })
                .PrimaryKey(t => t.Code);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FloutecInterData", "FloutecMeasureLineId", "dbo.FloutecMeasureLines");
            DropIndex("dbo.FloutecInterData", new[] { "FloutecMeasureLineId" });
            DropTable("dbo.FloutecIntersTypes");
            DropTable("dbo.FloutecInterData");
        }
    }
}
