using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Data
{
    public class invoiceProducts
    {
        public int id { get; set; }
        public virtual products products { get; set; }
        public int productId { get; set; }
        public virtual invoices invoices { get; set; }
        public int invoiceId { get; set; }
        public decimal price { get; set; }
        public int taxRate { get; set; } 
        public decimal taxPrice { get; set; }
        public int totalCount { get; set; } = 1;
        public decimal grandTotal { get; set; } 
        public DateTime createDate { get; set; } = DateTime.Now;
        public Data.Enums.GeneralStatus status { get; set; } = Enums.GeneralStatus.active;
    }
}
