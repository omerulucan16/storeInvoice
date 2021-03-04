namespace moreDevelopment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgInvoiceProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.invoiceProducts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        productId = c.Int(nullable: false),
                        invoiceId = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        taxRate = c.Int(nullable: false),
                        taxPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        grandTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        createDate = c.DateTime(nullable: false, precision: 0),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.invoices", t => t.invoiceId)
                .ForeignKey("dbo.products", t => t.productId)
                .Index(t => t.productId)
                .Index(t => t.invoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.invoiceProducts", "productId", "dbo.products");
            DropForeignKey("dbo.invoiceProducts", "invoiceId", "dbo.invoices");
            DropIndex("dbo.invoiceProducts", new[] { "invoiceId" });
            DropIndex("dbo.invoiceProducts", new[] { "productId" });
            DropTable("dbo.invoiceProducts");
        }
    }
}
