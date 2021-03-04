using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Data.Mapping
{
    class invoicesMap : EntityTypeConfiguration<invoices>
    {
        public invoicesMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.createDate).IsRequired();
            this.Property(t => t.sendDate).IsRequired();
            this.Property(t => t.buyerAdress).HasMaxLength(255).IsRequired();
            this.Property(t => t.buyerName).HasMaxLength(255).IsRequired();
            this.Property(t => t.buyerSurname).HasMaxLength(255).IsRequired();
            this.Property(t => t.price).IsRequired();
            this.Property(t => t.taxPrice).IsRequired();
            this.Property(t => t.grandTotal).IsRequired();
            this.Property(t => t.status).IsRequired();
        }
    }
}
