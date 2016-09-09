namespace EasyMaintain.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class supplierNameAdded : DbMigration
    {
        public override void Up()
        {
           
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
                "dbo.EngineTypes",
                c => new
                    {
                        EngineTypeID = c.Int(nullable: false, identity: true),
                        EngineTypeName = c.String(),
                        ManufacturerID = c.Int(nullable: false),
                        AdditionalData = c.String(),
                    })
                .PrimaryKey(t => t.EngineTypeID);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        AdditionalData = c.String(),
                        ManufacturerName = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerID);
            
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
                    EngineType_EngineTypeID = c.Int(),
                    Manufacturer_ManufacturerID = c.Int(),
                })
                .PrimaryKey(t => t.AircraftModelID)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryID)
                .ForeignKey("dbo.EngineTypes", t => t.EngineType_EngineTypeID)
                .ForeignKey("dbo.Manufacturers", t => t.Manufacturer_ManufacturerID)
                .Index(t => t.Category_CategoryID)
                .Index(t => t.EngineType_EngineTypeID)
                .Index(t => t.Manufacturer_ManufacturerID);

        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpareParts", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.AircraftModels", "Manufacturer_ManufacturerID", "dbo.Manufacturers");
            DropForeignKey("dbo.AircraftModels", "EngineType_EngineTypeID", "dbo.EngineTypes");
            DropForeignKey("dbo.AircraftModels", "Category_CategoryID", "dbo.Categories");
            DropIndex("dbo.SpareParts", new[] { "Category_CategoryID" });
            DropIndex("dbo.AircraftModels", new[] { "Manufacturer_ManufacturerID" });
            DropIndex("dbo.AircraftModels", new[] { "EngineType_EngineTypeID" });
            DropIndex("dbo.AircraftModels", new[] { "Category_CategoryID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.SpareParts");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.EngineTypes");
            DropTable("dbo.Categories");
            DropTable("dbo.AircraftModels");
        }
    }
}
