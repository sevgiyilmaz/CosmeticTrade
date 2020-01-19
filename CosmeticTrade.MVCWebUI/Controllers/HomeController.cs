using CosmeticTrade.BLL.Repositories.RepositoryClass;
using CosmeticTrade.DAL.ORM.Entity;
using CosmeticTrade.MVCWebUI.Models.DTO.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticTrade.MVCWebUI.Controllers
{    
    public class HomeController : Controller
    {
        ProductRepository pr = new ProductRepository();
        CategoryRepository cr = new CategoryRepository();
        OrderDetailRepository odr = new OrderDetailRepository();
        CommentaryRepository cor = new CommentaryRepository();
        UserRepository ur = new UserRepository();
        // GET: Home                
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int id)
        {
            if (pr.SelectAll().Any(i => i.Id == id))
            {
                return View(pr.SelectById(id));
            }
            return RedirectToAction("Index");

        }
        public ActionResult List(string Brand, string Category)
        {
            if (pr.SelectAll().FirstOrDefault(i=>i.Brand==Brand) != null)
            {
                var brandproducts = pr.SelectAll().Where(i => i.Brand == Brand).ToList();
                return View(brandproducts);
            }
            else if (cr.SelectByName(Category) != null)
            {
                var categoryproducts = cr.SelectAll().FirstOrDefault(i => i.Name == Category);
                return View(categoryproducts.Products.ToList());
            }
            else
            {
                return View(pr.SelectAll());
            }
        }       

        public PartialViewResult _NavbarBrands()
        {
            return PartialView(pr.GetBrands());
        }

        public PartialViewResult _GetCategories()
        {
            return PartialView(cr.SelectAll());
        }

        public PartialViewResult _BestSellers()
        {
            var bestSellers = odr.SelectAll().GroupBy(i => i.ProductId).Select(i => new
            {
                productId = i.Key,
                quantity = i.Sum(a => a.Quantity)
            }).OrderByDescending(i => i.quantity).Take(3).ToList();
            var bestS = new List<Product>();
            foreach (var item in bestSellers)
            {
                bestS.Add(pr.SelectById(item.productId));
            }
            return PartialView(bestS.Where(i => i.Stock > 0).ToList());
        }

        public PartialViewResult _MonthBestSeller()
        {
            var monthBestSellers = odr.SelectAll().Where(i => i.CreatedDate.Month == DateTime.Now.Month - 1).GroupBy(i => i.ProductId).Select(i => new
            {
                productId = i.Key,
                quantity = i.Sum(a => a.Quantity)
            }).OrderByDescending(i => i.quantity).FirstOrDefault();
            var product = pr.SelectById(monthBestSellers == null ? 1 : monthBestSellers.productId);
            return PartialView(product);
        }

        public ActionResult Search(string search)
        {
            if (search != null)
            {
                ViewBag.Search = search;
                search = search.ToLower().Trim();
                var products = pr.SelectAll().Where(i => i.Name.ToLower().Contains(search) || i.Brand.ToLower().Contains(search) || i.Code == search).ToList();
                foreach (var category in cr.SelectAll().Where(i => i.Name.ToLower().Contains(search)).ToList())
                {
                    products.AddRange(category.Products);
                }

                products = products.Distinct().ToList();
                return View(products);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveCommentary(bool? likevalue, string comment, int ProductId)
        {
            if (!String.IsNullOrWhiteSpace(comment))
            {
            var comMent = new Commentary();
            comMent.Description = comment.Trim();
            comMent.Like = likevalue;
            comMent.UserId = ur.SelectAll().FirstOrDefault(i => i.Username == User.Identity.Name).Id;
            comMent.ProductId = ProductId;

            cor.AddOrUpdate(comMent);
            }
            return Redirect("Detail/" + ProductId);
        }
    }
}