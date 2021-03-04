namespace moreDevelopment.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mgProductPrices : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.products", "price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.products", "price");
        }
    }
}
