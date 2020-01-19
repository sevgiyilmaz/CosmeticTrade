using CosmeticTrade.BLL.DbTools;
using CosmeticTrade.BLL.Repositories.Interface;
using CosmeticTrade.DAL.ORM.Context;
using CosmeticTrade.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.BLL.Repositories.RepositoryClass
{
    public class ProductRepository : IRepository<Product>
    {
        DataContext db = DbTool.DbInstance;

        public bool AddOrUpdate(Product entity)
        {
            if (entity == null)
            {
                throw new Exception("Added value is empty.Please,try again...");
            }
            else
            {
                db.Products.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(Product entity)
        {
            if (entity == null)
            {
                throw new Exception("Deleted value is empty.Please,try again...");
            }
            else
            {
                var product = db.Products.Find(entity.Id);
                product.IsDeleted = true;
                return this.AddOrUpdate(product);
            }
        }

        public List<Product> SelectAll()
        {

            //var products = db.Products.Where(i => i.IsDeleted == false && i.Insales == true).ToList();
            //List<Product> listProducts = new List<Product>();
            //foreach (var product in products)
            //{
            //    foreach (var img in product.Images.ToList())
            //    {
            //        if (img.IsDeleted)
            //        {
            //            product.Images.Remove(img);
            //        }
            //    }
            //    listProducts.Add(product);
            //}
            //return listProducts;




            return db.Products.Where(i => i.IsDeleted == false).ToList();
        }

        public Product SelectById(int id)
        {
            //var product = db.Products.Where(i => i.IsDeleted == false && i.Id == id).FirstOrDefault();
            //if (product == null) return null;
            //foreach (var image in product.Images.ToList())
            //{
            //    if (image.IsDeleted)
            //    {
            //        product.Images.Remove(image);
            //    }
            //}
            //return product;
            return db.Products.Where(i => i.IsDeleted == false && i.Id == id).FirstOrDefault();
        }

        public List<string> GetBrands()
        {
            var BrandList = new List<string>();
            foreach (var product in SelectAll())
            {
                BrandList.Add(product.Brand);
            }
            return BrandList.Distinct().ToList();
        }
    }
}
