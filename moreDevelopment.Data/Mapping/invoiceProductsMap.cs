using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Data.Mapping
{
    class invoiceProductsMap : EntityTypeConfiguration<invoiceProducts>
    {
        public invoiceProductsMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.createDate).IsRequired();
            this.Property(t => t.price).IsRequired();
            this.Property(t => t.taxPrice).IsRequired();
            this.Property(t => t.taxRate).IsRequired();
            this.Property(t => t.grandTotal).IsRequired();
            this.Property(t => t.status).IsRequired();
            HasRequired(r => r.invoices)
          .WithMany()
          .HasForeignKey(r => r.invoiceId).WillCascadeOnDelete(false);
            HasRequired(r => r.products)
         .WithMany()
         .HasForeignKey(r => r.productId).WillCascadeOnDelete(false);
        }
    }
}
