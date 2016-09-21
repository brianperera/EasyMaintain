namespace EasyMaintain.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CrewID : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EngineType", newName: "Maintenance");
            RenameColumn(table: "dbo.MaintenanceChecks", name: "EngineType_WorkID", newName: "Maintenance_WorkID");
            RenameColumn(table: "dbo.Crews", name: "EngineType_WorkID", newName: "Maintenance_WorkID");
            RenameIndex(table: "dbo.MaintenanceChecks", name: "IX_EngineType_WorkID", newName: "IX_Maintenance_WorkID");
            RenameIndex(table: "dbo.Crews", name: "IX_EngineType_WorkID", newName: "IX_Maintenance_WorkID");
            DropPrimaryKey("dbo.Crews");
            AddColumn("dbo.Crews", "CrewID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.DeliveryDetails", "DeliveryDate", c => c.String());
            AddColumn("dbo.DeliveryDetails", "DeliveryMethod", c => c.String());
            AddColumn("dbo.DeliveryDetails", "PersonInCharge", c => c.String());
            AddColumn("dbo.DeliveryDetails", "AddressLine1", c => c.String());
            AddColumn("dbo.DeliveryDetails", "AddressLine2", c => c.String());
            AddColumn("dbo.DeliveryDetails", "City", c => c.String());
            AddColumn("dbo.DeliveryDetails", "State", c => c.String());
            AddColumn("dbo.DeliveryDetails", "AddtionalNotes", c => c.String());
            AlterColumn("dbo.Crews", "Name", c => c.String());
            AddPrimaryKey("dbo.Crews", "CrewID");
            DropColumn("dbo.DeliveryDetails", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DeliveryDetails", "MyProperty", c => c.String());
            DropPrimaryKey("dbo.Crews");
            AlterColumn("dbo.Crews", "Name", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.DeliveryDetails", "AddtionalNotes");
            DropColumn("dbo.DeliveryDetails", "State");
            DropColumn("dbo.DeliveryDetails", "City");
            DropColumn("dbo.DeliveryDetails", "AddressLine2");
            DropColumn("dbo.DeliveryDetails", "AddressLine1");
            DropColumn("dbo.DeliveryDetails", "PersonInCharge");
            DropColumn("dbo.DeliveryDetails", "DeliveryMethod");
            DropColumn("dbo.DeliveryDetails", "DeliveryDate");
            DropColumn("dbo.Crews", "CrewID");
            AddPrimaryKey("dbo.Crews", "Name");
            RenameIndex(table: "dbo.Crews", name: "IX_Maintenance_WorkID", newName: "IX_EngineType_WorkID");
            RenameIndex(table: "dbo.MaintenanceChecks", name: "IX_Maintenance_WorkID", newName: "IX_EngineType_WorkID");
            RenameColumn(table: "dbo.Crews", name: "Maintenance_WorkID", newName: "EngineType_WorkID");
            RenameColumn(table: "dbo.MaintenanceChecks", name: "Maintenance_WorkID", newName: "EngineType_WorkID");
            RenameTable(name: "dbo.Maintenance", newName: "EngineType");
        }
    }
}
