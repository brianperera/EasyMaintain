namespace EasyMaintain.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ComponentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Components",
                c => new
                    {
                        ComponentID = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        ComponentName = c.String(),
                        Manufacturer = c.String(),
                        Description = c.String(),
                        ImagePath = c.String(),
                        AdditionalData = c.String(),
                    })
                .PrimaryKey(t => t.ComponentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Components");
        }
    }
}
