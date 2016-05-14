namespace NGVSCAN.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Estimators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 200),
                        FieldId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        DateModified = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        IsDeleted = c.Boolean(nullable: false),
                        DateDeleted = c.DateTime(precision: 7, storeType: "datetime2"),
                        Name = c.String(nullable: false, maxLength: 25),
                        Description = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Floutecs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estimators", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ROC809s",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 15),
                        Port = c.Int(nullable: false),
                        ROCUnit = c.Int(nullable: false),
                        ROCGroup = c.Int(nullable: false),
                        HostUnit = c.Int(nullable: false),
                        HostGroup = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estimators", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ROC809s", "Id", "dbo.Estimators");
            DropForeignKey("dbo.Floutecs", "Id", "dbo.Estimators");
            DropForeignKey("dbo.Estimators", "FieldId", "dbo.Fields");
            DropIndex("dbo.ROC809s", new[] { "Id" });
            DropIndex("dbo.Floutecs", new[] { "Id" });
            DropIndex("dbo.Estimators", new[] { "FieldId" });
            DropTable("dbo.ROC809s");
            DropTable("dbo.Floutecs");
            DropTable("dbo.Fields");
            DropTable("dbo.Estimators");
        }
    }
}
