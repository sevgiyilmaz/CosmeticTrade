using CosmeticTrade.BLL.Repositories.RepositoryClass;
using CosmeticTrade.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CosmeticTrade.MVCWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        CategoryRepository cr = new CategoryRepository();
        // GET: Admin/Category
        public ActionResult List()
        {
            return View(cr.SelectAll());
        }

        public ActionResult Delete(int id)
        {
            Category category = cr.SelectById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //cr.Delete(cr.SelectById(id));
            //return RedirectToAction("List");
            if (cr.SelectById(id) != null)
            {
                cr.Delete(cr.SelectById(id));
            }
            return RedirectToAction("List");
        }

        public ActionResult AddOrUpdate(int id = 0)
        {
            var category = new Category();
            if (id != 0) category = cr.SelectById(id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(Category model)
        {
            if (ModelState.IsValid)
            {
                var cat = new Category();
                if (model.Id != 0) cat = cr.SelectById(model.Id);
                cat.Name = model.Name;
                cat.Description = model.Description;
                cr.AddOrUpdate(cat);

                return RedirectToAction("List");
            }
            return View(model);
        }

        //public ActionResult AddOrUpdate(string Name, string Description, int id)
        //{
        //    if (!string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(Description))
        //    {
        //        var cat = cr.SelectById(id);
        //        cat.Name = Name;
        //        cat.Description = Description;
        //        cr.AddOrUpdate(cat);
        //    }
        //    else if (!string.IsNullOrWhiteSpace(Name))
        //    {
        //        var cat = new Category();
        //        cat.Name = Name;
        //        cat.Description = Description;
        //        cr.AddOrUpdate(cat);
        //    }
        //    return RedirectToAction("List");

        //}
    }
}