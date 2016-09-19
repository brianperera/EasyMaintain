namespace EasyMaintain.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AircraftModels",
                c => new
                    {
                        AircraftModelID = c.Int(nullable: false, identity: true),
                        ModelName = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                        AdditionalData = c.String(),
                        Category_CategoryID = c.Int(),
                        EngineType_WorkID = c.Int(),
                        Manufacturer_ManufacturerID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AircraftModelID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.EngineType", t => t.EngineType_WorkID)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_ManufacturerID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.EngineType_WorkID)
                .Index(t => t.Manufacturer_ManufacturerID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        AdditionalData = c.String(),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.EngineType",
                c => new
                    {
                        WorkID = c.Int(nullable: false, identity: true),
                        FlightModel = c.String(),
                        FlightNumber = c.String(),
                        Description = c.String(),
                        StartDate = c.String(),
                        CompletionDate = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.WorkID);
            
            CreateTable(
                "dbo.MaintenanceChecks",
                c => new
                    {
                        Description = c.String(nullable: false, maxLength: 128),
                        status = c.Boolean(nullable: false),
                        EngineType_WorkID = c.Int(),
                    })
                .PrimaryKey(t => t.Description)
                .ForeignKey("dbo.EngineType", t => t.EngineType_WorkID)
                .Index(t => t.EngineType_WorkID);
            
            CreateTable(
                "dbo.Crews",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Designation = c.String(),
                        EngineType_WorkID = c.Int(),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.EngineType", t => t.EngineType_WorkID)
                .Index(t => t.EngineType_WorkID);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        AdditionalData = c.String(),
                        ManufacturerName = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerID);
            
            CreateTable(
                "dbo.ComponentWorks",
                c => new
                    {
                        WorkID = c.Int(nullable: false, identity: true),
                        Component = c.String(),
                        SerialNumber = c.String(),
                        FlightNumber = c.String(),
                        Description = c.String(),
                        CreatedDate = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.WorkID);
            
            CreateTable(
                "dbo.SpareParts",
                c => new
                    {
                        SparePartID = c.Int(nullable: false, identity: true),
                        SparePartName = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                        AdditionalData = c.String(),
                        Category_CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.SparePartID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .Index(t => t.Category_CategoryID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        ContactDetails = c.String(),
                        EmailAddress = c.String(),
                        AdditionalData = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpareParts", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AircraftModels", "Manufacturer_ManufacturerID", "dbo.Manufacturers");
            DropForeignKey("dbo.AircraftModels", "EngineType_WorkID", "dbo.EngineType");
            DropForeignKey("dbo.Crews", "EngineType_WorkID", "dbo.EngineType");
            DropForeignKey("dbo.MaintenanceChecks", "EngineType_WorkID", "dbo.EngineType");
            DropForeignKey("dbo.AircraftModels", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.SpareParts", new[] { "Category_CategoryID" });
            DropIndex("dbo.Crews", new[] { "EngineType_WorkID" });
            DropIndex("dbo.MaintenanceChecks", new[] { "EngineType_WorkID" });
            DropIndex("dbo.AircraftModels", new[] { "Manufacturer_ManufacturerID" });
            DropIndex("dbo.AircraftModels", new[] { "EngineType_WorkID" });
            DropIndex("dbo.AircraftModels", new[] { "Category_CategoryID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.SpareParts");
            DropTable("dbo.ComponentWorks");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Crews");
            DropTable("dbo.MaintenanceChecks");
            DropTable("dbo.EngineType");
            DropTable("dbo.Categories");
            DropTable("dbo.AircraftModels");
        }
    }
}
