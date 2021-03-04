using moreDevelopment.Data;
using moreDevelopment.Service.Contracts;
using moreDevelopment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace moreDevelopment.Service
{
   public class InvoiceService : IInvoicesService
    {
        IProductService _productService = new ProductService();
        MainContext db = new MainContext();
        public invoiceListViewModel getInvoicesList()
        {
            invoiceListViewModel model = new invoiceListViewModel();
            model.invoiceList = new List<invoiceViewModel>();
            AutoMapper.Mapper.Map(db.invoices.Where(w => w.status == Data.Enums.GeneralStatus.active).OrderByDescending(o => o.createDate).ToList(), model.invoiceList);
            return model;
        }
        public createInvoiceViewModel addNewInvoice(createInvoiceViewModel model)
        {
            model.result = true;
            if (!checkConstract(model))
            {
                model.result = false;
                return model;
            }
            foreach (var item in model.productList.productList.Where(w=>w.id == 0))
            {
                int itemAddResult = _productService.saveNewProduct(item);
                if (itemAddResult == 0)
                {
                    model.result = false;
                    return model;
                }
                else
                {
                    item.id = itemAddResult;
                }
            }
            if (!addNewInvoiceInformations(model))
                model.result = false;
            return model;
        }
        private bool checkConstract(createInvoiceViewModel model)
        {
            bool result = true;
            if (model.buyerAdress == null || 
                model.buyerName == null || 
                model.buyerSurname == null || 
                model.productList.productList.Count == 0 ||
                model.productList.productList.Where(w=>w.price == 0 || w.TaxRate == 0 || w.count == 0).Count()>0 )
            {
                result = false;
            }
            return result;

        }
        private bool addNewInvoiceInformations(createInvoiceViewModel model)
        {
            decimal total = 0,
                    totalTax = 0,
                    grandTotal = 0;
            bool result = true;
            invoices createInvoiceModel = new invoices();
            AutoMapper.Mapper.Map(model, createInvoiceModel);
            foreach (var item in model.productList.productList)
            {
                total = total + item.price * item.count;
                totalTax =totalTax + ((item.price * item.count) * item.TaxRate) / 100;
                
            }
            grandTotal = grandTotal + (total + totalTax);
            createInvoiceModel.grandTotal = grandTotal;
            createInvoiceModel.taxPrice = totalTax;
            createInvoiceModel.price = total;
            db.invoices.Add(createInvoiceModel);
            if(db.SaveChanges() > 0)
            {
                int InvoiceId = createInvoiceModel.id;
                
                foreach (var item in model.productList.productList)
                {
                    invoiceProducts createInvoiceProductsModel = new invoiceProducts();
                    AutoMapper.Mapper.Map(item, createInvoiceProductsModel);
                    createInvoiceProductsModel.invoiceId = InvoiceId;
                    createInvoiceProductsModel.productId = item.id;
                    createInvoiceProductsModel.totalCount = item.count;
                    db.invoiceProducts.Add(createInvoiceProductsModel);
                }
                if (db.SaveChanges()>0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
               
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}
