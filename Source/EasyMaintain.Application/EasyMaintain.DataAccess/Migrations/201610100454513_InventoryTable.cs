namespace EasyMaintain.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InventoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CompanyName = c.String(),
                        AdditionalNotes = c.String(),
                        InvoiceNumber = c.Int(nullable: false),
                        PaymentMethod = c.String(),
                        PaymentNotes = c.String(),
                        BillingAddress = c.String(),
                        BillingName = c.String(),
                        OrderType = c.Boolean(nullable: false),
                        Deliverydetails_DeliveryDetailsId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.DeliveryDetails", t => t.Deliverydetails_DeliveryDetailsId)
                .Index(t => t.Deliverydetails_DeliveryDetailsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "Deliverydetails_DeliveryDetailsId", "dbo.DeliveryDetails");
            DropIndex("dbo.Inventories", new[] { "Deliverydetails_DeliveryDetailsId" });
            DropTable("dbo.Inventories");
        }
    }
}
