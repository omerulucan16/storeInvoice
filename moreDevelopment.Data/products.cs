using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Data
{
    
    public class products
    {
        
        public int id { get; set; }
        public string Name { get; set; }
        public string SupplierCode { get; set; }
        public decimal price { get; set; } = Convert.ToDecimal(new Random().Next(1,50));
        public DateTime createDate { get; set; } = DateTime.Now;
        public Data.Enums.GeneralStatus status { get; set; } = Enums.GeneralStatus.active;

        //public ICollection<invoiceProducts> productsInvoiceRelation { get; set; }
    }
}
