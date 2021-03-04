namespace moreDevelopment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgTaxRate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.invoiceProducts", "totalCount", c => c.Int(nullable: false));
            DropColumn("dbo.invoices", "taxRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.invoices", "taxRate", c => c.Int(nullable: false));
            DropColumn("dbo.invoiceProducts", "totalCount");
        }
    }
}
