using moreDevelopment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Service.Contracts
{
    public interface IProductService
    {
        productsListViewModel getProductsList();
        int saveNewProduct(productsViewModel model);
        productsViewModel getProductDetail(int id);
        bool updateProductDetail(productsViewModel model);
    }
}
