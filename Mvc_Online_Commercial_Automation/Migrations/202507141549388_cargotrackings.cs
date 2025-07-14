namespace Mvc_Online_Commercial_Automation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cargotrackings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CargoDetails",
                c => new
                    {
                        CargoDetailId = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 300, unicode: false),
                        CargoTrackingNumber = c.String(maxLength: 10, unicode: false),
                        Employee = c.String(maxLength: 20, unicode: false),
                        Cari = c.String(maxLength: 25, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoDetailId);
            
            CreateTable(
                "dbo.CargoTrackings",
                c => new
                    {
                        CargoTrackingID = c.Int(nullable: false, identity: true),
                        CargoTrackingNumber = c.String(maxLength: 10, unicode: false),
                        Description = c.String(maxLength: 100, unicode: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CargoTrackingID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CargoTrackings");
            DropTable("dbo.CargoDetails");
        }
    }
}
