using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using moreDevelopment.Service;
using moreDevelopment.Service.Contracts;
using moreDevelopment.ViewModel;

namespace moreDevelopment.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService = new ProductService();
        IInvoicesService _InvoicesService = new InvoiceService();
        [Route("")]
        public ActionResult Index()
        {
            // ToastrService.AddToUserQueue("Sistemde böyle bir kayıt bulunamadı veya aktif edilmiş kayıt.", "Lol Tahmin", Data.Enums.ToastrType.Error);
            return View(_InvoicesService.getInvoicesList());
        }
        [Route("yeni-fatura")]
        public ActionResult Create()
        {
            createInvoiceViewModel model = new createInvoiceViewModel();
            model.productList = new productsListViewModel();
            model.ownProducts = new productsListViewModel();
            model.productList.productList = new List<productsViewModel>();
            model.ownProducts = _productService.getProductsList();
            return View(model);
        }

        [Route("yeni-fatura")]
        [HttpPost]
        public ActionResult Create(createInvoiceViewModel model)
        {

             model = _InvoicesService.addNewInvoice(model);
            if(!model.result)
            {
                ToastrService.AddToUserQueue("Kayıt sırasında bir hata oluşmuştur.", "Kuaför Store", Data.Enums.ToastrType.Error);
                model.ownProducts = new productsListViewModel();
                model.ownProducts = _productService.getProductsList();
                return View(model);
            }
            return new Rotativa.ViewAsPdf("Print",model) {
                PageOrientation = Rotativa.Options.Orientation.Landscape,
                PageSize = Rotativa.Options.Size.A4,
                PageMargins = new Rotativa.Options.Margins(0, 0, 0, 0)
            };
        }

    }
}