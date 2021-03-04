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
   public class ProductService : IProductService
    {
        MainContext db = new MainContext();
        public productsListViewModel getProductsList()
        {
            productsListViewModel model = new productsListViewModel();
            model.productList = new List<productsViewModel>();
            AutoMapper.Mapper.Map(db.products.Where(w => w.status == Data.Enums.GeneralStatus.active).ToList(),model.productList);
            return model;
        }
        public productsViewModel getProductDetail(int id)
        {
            productsViewModel model = new productsViewModel();
            AutoMapper.Mapper.Map(db.products.Find(id), model);
            return model;
        }
        public bool updateProductDetail(productsViewModel model)
        {
            products updateModel = db.products.Find(model.id);

            AutoMapper.Mapper.Map(model, updateModel);
            updateModel.createDate = DateTime.Now;
            if (db.SaveChanges() > 0)
                return true;
            else
                return false;
        }
        
        public int saveNewProduct(productsViewModel model)
        {
            int result = 0;
            products createModel = new products();
            AutoMapper.Mapper.Map(model, createModel);
            db.products.Add(createModel);
            if (db.SaveChanges()>0)
            {
                result = createModel.id;
            }
            return result;
        }
    }
}
