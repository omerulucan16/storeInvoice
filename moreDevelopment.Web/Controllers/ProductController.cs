using moreDevelopment.Service;
using moreDevelopment.Service.Contracts;
using moreDevelopment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace moreDevelopment.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService = new ProductService();
        IInvoicesService _InvoicesService = new InvoiceService();
        [Route("urun-listesi")]
        public ActionResult Index()
        {
            // ToastrService.AddToUserQueue("Sistemde böyle bir kayıt bulunamadı veya aktif edilmiş kayıt.", "Lol Tahmin", Data.Enums.ToastrType.Error);
            return View(_productService.getProductsList());
        }
        [Route("urun-olustur")]
        public ActionResult Create()
        {
            return View(new productsViewModel());
        }
        [HttpPost]
        [Route("urun-olustur")]
        public ActionResult Create(productsViewModel model)
        {
            if (_productService.saveNewProduct(model) != 0)
            {
                ToastrService.AddToUserQueue("Ürün başarıyla oluşturuldu.", "Kuaför Store", Data.Enums.ToastrType.Success);
                return Redirect("~/urun-listesi");

            }
            else
            {
                ToastrService.AddToUserQueue("Ürün bilgilerinde hata oluştu.", "Kuaför Store", Data.Enums.ToastrType.Error);
                return View(model);
            }
            
        }
        [Route("urun-detay/{id:int}")]
        public ActionResult Detail(int id)
        {
            return View(_productService.getProductDetail(id));
        }
        [HttpPost]
        [Route("urun-detay/{id:int}")]
        public ActionResult Detail(productsViewModel model)
        {
            if (_productService.updateProductDetail(model)) {
                ToastrService.AddToUserQueue("Ürün başarıyla güncellendi.", "Kuaför Store", Data.Enums.ToastrType.Success);
                return Redirect("~/urun-listesi");
            }
            else
            {
                ToastrService.AddToUserQueue("Ürün bilgilerinde hata oluştu.", "Kuaför Store", Data.Enums.ToastrType.Error);
                return View(model);
            }
               
           
        }

        [HttpGet]
        [Route("urun/urun-listesi")]
        public ActionResult  getProductList()
        {
            return Json(_productService.getProductsList(), JsonRequestBehavior.AllowGet);  
        }
    }
}