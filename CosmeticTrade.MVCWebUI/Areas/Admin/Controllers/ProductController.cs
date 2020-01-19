using CosmeticTrade.BLL.Repositories.RepositoryClass;
using CosmeticTrade.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticTrade.MVCWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        ProductRepository pr = new ProductRepository();
        CategoryRepository cr = new CategoryRepository();
        ImageRepository ir = new ImageRepository();
        // GET: Admin/Product
        public ActionResult List()
        {
            return View(pr.SelectAll());
        }
        public ActionResult Delete(int id)
        {
            Product product = pr.SelectById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //cr.Delete(cr.SelectById(id));
            //return RedirectToAction("List");
            if (pr.SelectById(id) != null)
            {
                pr.Delete(pr.SelectById(id));
            }
            return RedirectToAction("List");
        }

        public ActionResult AddOrUpdate(int id = 0)
        {
            var product = new Product();
            if (id != 0) product = pr.SelectById(id);

            ViewBag.Category = new SelectList(cr.SelectAll(), "Id", "Name");

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(Product model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product();
                if (model.Id != 0) product = pr.SelectById(model.Id);
                if (model.Img.FirstOrDefault() != null)
                {
                    foreach (var img in model.Img)
                    {
                        string imgPath = "/Content/Images/PLimg/" + img.FileName;
                        img.SaveAs(Server.MapPath(imgPath));
                        var image = new Image();
                        image.ImageUrl = imgPath;
                        product.Images.Add(image);
                    }
                }
                if (model.ImageIds != null)
                {
                    var imageIds = model.ImageIds.Split(',');
                    foreach (var id in imageIds)
                    {
                        if (id != "")
                        {
                            ir.Delete(ir.SelectById(Convert.ToInt32(id)));
                        }
                    }
                }

                product.Name = model.Name;
                product.Brand = model.Brand;
                product.Description = model.Description;
                product.Stock = model.Stock;
                product.Price = model.Price;
                product.Insales = model.Insales;
                product.CategoryId = model.CategoryId;
                pr.AddOrUpdate(product);

                return RedirectToAction("List");
            }
            ViewBag.Category = new SelectList(cr.SelectAll(), "Id", "Name");
            return View(model);
        }
    }
}