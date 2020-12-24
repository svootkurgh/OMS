namespace Navtech.OMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identity = c.String(nullable: false, maxLength: 15),
                        AddressLine1 = c.String(nullable: false, maxLength: 75),
                        AddressLine2 = c.String(maxLength: 75),
                        Landmark = c.String(maxLength: 75),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 50),
                        Pincode = c.String(nullable: false, maxLength: 10),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.Buyers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        MiddleName = c.String(maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        MobileNumber = c.String(nullable: false, maxLength: 15),
                        AlternateMobileNumber = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        BuyerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Buyers", t => t.BuyerId, cascadeDelete: true)
                .Index(t => t.BuyerId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Price = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        Image = c.String(nullable: false, maxLength: 150),
                        SKU = c.String(nullable: false, maxLength: 20),
                        Barcode = c.String(nullable: false, maxLength: 25),
                        AvailableQuantity = c.String(nullable: false),
                        OrderedQuantity = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "BuyerId", "dbo.Buyers");
            DropForeignKey("dbo.Products", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "BuyerId", "dbo.Buyers");
            DropIndex("dbo.Products", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "BuyerId" });
            DropIndex("dbo.Addresses", new[] { "BuyerId" });
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Buyers");
            DropTable("dbo.Addresses");
        }
    }
}
