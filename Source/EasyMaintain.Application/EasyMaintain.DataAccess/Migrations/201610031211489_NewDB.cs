namespace EasyMaintain.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AircraftModels",
                c => new
                    {
                        AircraftModelID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        ModelName = c.String(),
                        Manufacturer = c.String(),
                        EngineType = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                        AdditionalData = c.String(),
                    })
                .PrimaryKey(t => t.AircraftModelID);
            
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
                        Deliverydetails_DeliveryDetailsId = c.Int(),
                    })
                .PrimaryKey(t => t.WorkID)
                .ForeignKey("dbo.DeliveryDetails", t => t.Deliverydetails_DeliveryDetailsId)
                .Index(t => t.Deliverydetails_DeliveryDetailsId);
            
            CreateTable(
                "dbo.DeliveryDetails",
                c => new
                    {
                        DeliveryDetailsId = c.Int(nullable: false, identity: true),
                        DeliveryDate = c.String(),
                        DeliveryMethod = c.String(),
                        PersonInCharge = c.String(),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        AddtionalNotes = c.String(),
                    })
                .PrimaryKey(t => t.DeliveryDetailsId);
            
            CreateTable(
                "dbo.Crews",
                c => new
                    {
                        CrewID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Designation = c.String(),
                        Maintenance_WorkID = c.Int(),
                    })
                .PrimaryKey(t => t.CrewID)
                .ForeignKey("dbo.Maintenance", t => t.Maintenance_WorkID)
                .Index(t => t.Maintenance_WorkID);
            
            CreateTable(
                "dbo.MaintenanceChecks",
                c => new
                    {
                        MaintenanceCheckID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        status = c.Boolean(nullable: false),
                        Maintenance_WorkID = c.Int(),
                    })
                .PrimaryKey(t => t.MaintenanceCheckID)
                .ForeignKey("dbo.Maintenance", t => t.Maintenance_WorkID)
                .Index(t => t.Maintenance_WorkID);
            
            CreateTable(
                "dbo.Maintenance",
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
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        AdditionalData = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpareParts", "Category_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Crews", "Maintenance_WorkID", "dbo.Maintenance");
            DropForeignKey("dbo.MaintenanceChecks", "Maintenance_WorkID", "dbo.Maintenance");
            DropForeignKey("dbo.ComponentWorks", "Deliverydetails_DeliveryDetailsId", "dbo.DeliveryDetails");
            DropIndex("dbo.SpareParts", new[] { "Category_CategoryID" });
            DropIndex("dbo.MaintenanceChecks", new[] { "Maintenance_WorkID" });
            DropIndex("dbo.Crews", new[] { "Maintenance_WorkID" });
            DropIndex("dbo.ComponentWorks", new[] { "Deliverydetails_DeliveryDetailsId" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.SpareParts");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Maintenance");
            DropTable("dbo.MaintenanceChecks");
            DropTable("dbo.Crews");
            DropTable("dbo.DeliveryDetails");
            DropTable("dbo.ComponentWorks");
            DropTable("dbo.Categories");
            DropTable("dbo.AircraftModels");
        }
    }
}
