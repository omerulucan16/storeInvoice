using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.ViewModel
{
   public class invoiceViewModel
    {
        public int id { get; set; }
        public string invoiceNo { get; set; }
        public string buyerName { get; set; }
        public string buyerSurname { get; set; }
        public string buyerAdress { get; set; }
        public decimal price { get; set; }
        public decimal taxPrice { get; set; }
        public decimal grandTotal { get; set; }
        public DateTime createDate { get; set; }
    }
    public class invoiceListViewModel
    {
        public IList<invoiceViewModel> invoiceList { get; set; }
    }
}
