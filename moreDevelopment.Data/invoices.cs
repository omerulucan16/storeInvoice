using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Data
{
    public class invoices
    {
        public int id { get; set; }
        public string invoiceNo { get; set; }
        public string buyerName { get; set; }
        public string buyerSurname { get; set; }
        public string buyerAdress { get; set; }
        public decimal price { get; set; }
        public decimal taxPrice { get; set; }
        public decimal grandTotal { get; set; } 
        public DateTime createDate { get; set; } = DateTime.Now;
        public DateTime sendDate { get; set; } = DateTime.Now;
        public Data.Enums.GeneralStatus status { get; set; } = Enums.GeneralStatus.active;
        //public ICollection<invoiceProducts> invoiceInvoiceProductsRelation { get; set; }
    }
}
