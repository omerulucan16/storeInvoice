using moreDevelopment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Service.Contracts
{
    public interface IInvoicesService
    {
        createInvoiceViewModel addNewInvoice(createInvoiceViewModel model);
        invoiceListViewModel getInvoicesList();
        
    }
}
