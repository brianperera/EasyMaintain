namespace EasyMaintain.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPropertiesToDelivaryDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeliveryDetails",
                c => new
                    {
                        DeliverydetailsId = c.Int(nullable: true, identity: true),
                        MyProperty = c.String(),
                    })
                .PrimaryKey(t => t.DeliverydetailsId);
            
            AddColumn("dbo.ComponentWorks", "DeliverydetailsId", c => c.Int(nullable: false));
            CreateIndex("dbo.ComponentWorks", "DeliverydetailsId");
            AddForeignKey("dbo.ComponentWorks", "DeliverydetailsId", "dbo.DeliveryDetails", "DeliverydetailsId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComponentWorks", "DeliverydetailsId", "dbo.DeliveryDetails");
            DropIndex("dbo.ComponentWorks", new[] { "DeliverydetailsId" });
            DropColumn("dbo.ComponentWorks", "DeliverydetailsId");
            DropTable("dbo.DeliveryDetails");
        }
    }
}
