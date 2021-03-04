using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.ViewModel
{
   public class productsViewModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string SupplierCode { get; set; }
        public int count { get; set; }
        public int TaxRate { get; set; }
        public decimal price { get; set; }
        public DateTime createDate { get; set; } = DateTime.Now;
        public Data.Enums.GeneralStatus status { get; set; } = Data.Enums.GeneralStatus.active;
    }
    public class productsListViewModel
    {
        public IList<productsViewModel> productList { get; set; }
    }
}
