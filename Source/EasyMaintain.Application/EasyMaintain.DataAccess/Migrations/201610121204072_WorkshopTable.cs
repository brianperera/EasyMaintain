namespace EasyMaintain.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WorkshopTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workshops",
                c => new
                    {
                        WorkshopID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.WorkshopID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Workshops");
        }
    }
}
