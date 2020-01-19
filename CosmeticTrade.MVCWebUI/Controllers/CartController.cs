using CosmeticTrade.BLL.Repositories.RepositoryClass;
using CosmeticTrade.MVCWebUI.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticTrade.MVCWebUI.Controllers
{
    public class CartController : Controller
    {
        ProductRepository pr = new ProductRepository();
        // GET: Cart
        public ActionResult CartIndex()
        {
            return View(GetCart());
        }
        public ActionResult _NavbarCart()
        {
            return PartialView(GetCart());
        }
        public ActionResult AddToCart(int id)
        {
            var newpr = pr.SelectById(id);
            var quantity = GetCart().CartLine.FirstOrDefault(i => i.ProductId == newpr.Id) == null ? 0 : GetCart().CartLine.FirstOrDefault(i => i.ProductId == newpr.Id).Quantity;
            if (newpr != null && newpr.Stock > quantity)
            {
                CartItemModel cartItemModel = new CartItemModel();
                cartItemModel.ProductId = newpr.Id;
                cartItemModel.Name = newpr.Name;
                cartItemModel.Price = newpr.Price;
                cartItemModel.Image = newpr.Images.FirstOrDefault(i => i.IsDeleted == false) != null ? newpr.Images.FirstOrDefault(i=>i.IsDeleted==false).ImageUrl : "/Content/Images/None.jpg";
                cartItemModel.Quantity = 1;
                GetCart().Add(cartItemModel);
                return RedirectToAction("CartIndex");
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int id)
        {
            if (GetCart() != null)
            {
                GetCart().Remove(id);
            }
            return RedirectToAction("CartIndex");
        }

        public CartModel GetCart()
        {
            var cart = (CartModel)Session["Cart"];
            if (cart == null)
            {
                cart = new CartModel();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}