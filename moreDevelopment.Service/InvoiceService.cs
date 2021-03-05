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
            
            if (model.productList.productList.Where(w => w.TaxRate == 18).Count() > 0)
                model.taxRate = 18;
            else
                model.taxRate = model.productList.productList.Where(w => w.TaxRate == 18).FirstOrDefault().TaxRate;
            if (model.productList.productList.Where(w => w.TaxRate == 8).Count() > 0)
            {
                model.taxRate2 = model.productList.productList.Where(w => w.TaxRate == 8).FirstOrDefault().TaxRate;
                foreach (var item in model.productList.productList.Where(w => w.TaxRate == model.taxRate2))
                {

                    model.taxPrice2 = model.taxPrice2 + (((item.price * item.count )* item.TaxRate) / 100);
                }
               
            }
            model.taxPrice = model.taxPrice - model.taxPrice2;
            
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
        private string getTotalPriceText(decimal totalPrice)
        {
            string result = "";
            string totalPriceString = totalPrice.ToString();
            var splitPrice = totalPriceString.Split(',');
            if (splitPrice.Length == 1)
            {
                string numberfirst = "";
                string numbersecond = "";
                string numberthird = "";
                string valuefirst = "";
                string valuesecond = "";
                string valuethird = "";
                if (splitPrice[0].Length == 3)
                {
                    numberfirst = splitPrice[0].Substring(0, 1);
                    numbersecond = splitPrice[0].Substring(1, 1);
                    numberthird = splitPrice[0].Substring(2, 1);
                }
                else if (splitPrice[0].Length == 2)
                {
                    numberfirst = "";
                    numbersecond = splitPrice[0].Substring(0, 1);
                    numberthird = splitPrice[0].Substring(1, 1);
                }
                else
                {
                    numberfirst = "";
                    numbersecond = "";
                    numberthird = splitPrice[0].Substring(0, 1);
                }
                
                valuefirst = numberfirst == "" ? "" :  numberfirst == "1" ? "yüz" : getNumberToText(numberfirst,Data.Enums.PriceTextType.first) + "yüz";
                valuesecond = numbersecond == "" ? "" : numbersecond == "0" ? "" : getNumberToText(numbersecond, Data.Enums.PriceTextType.second);
                valuethird = numberthird == "0" ? "" : numberthird == "1" ? "bir" : getNumberToText(numberthird, Data.Enums.PriceTextType.first);
                result = valuefirst +(valuefirst == "" ? "" : " " ) + valuesecond + (valuesecond =="" ?"": " ")+ valuethird + " TL";
            }
            else if (splitPrice.Length == 2)
            {
                string numberfirst = "";
                string numbersecond = "";
                string numberthird = "";
                string valuefirst = "";
                string valuesecond = "";
                string valuethird = "";
                string numberpennyfirst = "";
                string numberpennysecond = "";
                string valuepennyfirst = "";
                string valuepennysecond = "";
                if (splitPrice[0].Length == 3)
                {
                    numberfirst = splitPrice[0].Substring(0, 1);
                    numbersecond = splitPrice[0].Substring(1, 1);
                    numberthird = splitPrice[0].Substring(2, 1);
                }
                else if (splitPrice[0].Length == 2)
                {
                    numberfirst = "";
                    numbersecond = splitPrice[0].Substring(0, 1);
                    numberthird = splitPrice[0].Substring(1, 1);
                }
                else
                {
                    numberfirst = "";
                    numbersecond = "";
                    numberthird = splitPrice[0].Substring(0, 1);
                }
                valuefirst = numberfirst == "" ? "" : numberfirst == "1" ? "yüz" : getNumberToText(numberfirst, Data.Enums.PriceTextType.first) + "yüz";
                valuesecond = numbersecond == "" ? "" : numbersecond == "0" ? "" : getNumberToText(numbersecond, Data.Enums.PriceTextType.second);
                valuethird = numberthird == "0" ? "" : numberthird == "1" ? "bir" : getNumberToText(numberthird, Data.Enums.PriceTextType.first);
                numberpennyfirst = splitPrice[1].Substring(0, 1);
                numberpennysecond = splitPrice[1].Substring(1, 1);
                valuepennyfirst = numberpennyfirst == "0" ? "" : getNumberToText(numberpennyfirst, Data.Enums.PriceTextType.second);
                valuepennysecond = numberpennysecond == "0" ? "" : getNumberToText(numberpennysecond, Data.Enums.PriceTextType.first);
                result = valuefirst + (valuefirst == "" ? "" : " ") + valuesecond + (valuesecond == "" ? "" : " ") + valuethird + " TL";
                if (splitPrice.Length == 2)
                {
                    result = result +( " " + valuepennyfirst +(valuepennyfirst == "" ? "" : " ") + valuepennysecond + (valuepennysecond == "" ? "" : " ")) +"KRŞ";
                }
            }
            return result;
        }
        private string getNumberToText(string number,Data.Enums.PriceTextType type)
        {
            switch (number)
            {
                case "0":
                    return "";
                case "1":
                    return type == Data.Enums.PriceTextType.first ? "":"on";
                case "2":
                    return type == Data.Enums.PriceTextType.first ? "iki" : "yirmi";
                case "3":
                    return type == Data.Enums.PriceTextType.first ? "üç" : "otuz";
                case "4":
                    return type == Data.Enums.PriceTextType.first ? "dört" : "kırk";
                case "5":
                    return type == Data.Enums.PriceTextType.first ? "beş" : "elli";
                case "6":
                    return type == Data.Enums.PriceTextType.first ? "altı" : "altmış";
                case "7":
                    return type == Data.Enums.PriceTextType.first ? "yedi" : "yetmiş";
                case "8":
                    return type == Data.Enums.PriceTextType.first ? "sekiz" : "seksen";
                case "9":
                    return type == Data.Enums.PriceTextType.first ? "dokuz" : "doksan";
                default:
                    return "";
            }
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
            if(result)
            {
                model.totalPriceText = getTotalPriceText(model.grandTotal);
            }
            return result;
        }
    }
}
