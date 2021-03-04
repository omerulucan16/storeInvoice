using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Data.Mapping
{
    class productsMap : EntityTypeConfiguration<products>
    {
        public productsMap()
        {
            this.HasKey(t => t.id);
            this.Property(t => t.createDate).IsRequired();
            this.Property(t => t.Name).HasMaxLength(255).IsRequired();
            this.Property(t => t.SupplierCode).IsOptional();
            this.Property(t => t.status).IsRequired();
        }
    }
}
