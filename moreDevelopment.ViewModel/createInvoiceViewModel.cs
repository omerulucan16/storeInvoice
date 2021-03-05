using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.ViewModel
{
   public class createInvoiceViewModel
    {
        public int id { get; set; }
        public string invoiceNo { get; set; }
        public string buyerName { get; set; }
        public string buyerSurname { get; set; }
        public string buyerAdress { get; set; }
        public decimal price { get; set; }
        public int taxRate { get; set; } = 18;
        public int taxRate2 { get; set; } = 16;
        public decimal taxPrice { get; set; }
        public decimal taxPrice2 { get; set; }
        public decimal grandTotal { get; set; }
        public DateTime createDate { get; set; } = DateTime.Now;
        public DateTime sendDate { get; set; } = DateTime.Now;
        public productsListViewModel productList { get; set; }
        public productsListViewModel ownProducts { get; set; }
        public bool result { get; set; }
        public string totalPriceText { get; set; }
    }

}
