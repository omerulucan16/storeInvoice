namespace moreDevelopment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgInvoiceFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invoices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        invoiceNo = c.String(unicode: false),
                        buyerName = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        buyerSurname = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        buyerAdress = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        taxRate = c.Int(nullable: false),
                        taxPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        grandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        createDate = c.DateTime(nullable: false, precision: 0),
                        sendDate = c.DateTime(nullable: false, precision: 0),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255, storeType: "nvarchar"),
                        SupplierCode = c.String(unicode: false),
                        createDate = c.DateTime(nullable: false, precision: 0),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.products");
            DropTable("dbo.invoices");
        }
    }
}
