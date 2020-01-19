using CosmeticTrade.BLL.Repositories.RepositoryClass;
using CosmeticTrade.DAL.ORM.Entity;
using CosmeticTrade.MVCWebUI.Models.Cart;
using CosmeticTrade.MVCWebUI.Models.VM.Order;
using CosmeticTrade.MVCWebUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CosmeticTrade.MVCWebUI.Controllers
{
    public class OrderController : Controller
    {
        UserRepository ur = new UserRepository();
        OrderRepository or = new OrderRepository();
        ShipperRepository sr = new ShipperRepository();
        ProductRepository pr = new ProductRepository();

        // GET: Order
        public ActionResult TimeOut()
        {
            return View();
        }

        public ActionResult Pay()
        {
            var cart = (CartModel)Session["Cart"];
            if (cart == null) return RedirectToAction("TimeOut");

            var user = ur.SelectAll().FirstOrDefault(i => i.Username == User.Identity.Name);

            var model = new PayVM();
            model.Cart = cart;
            model.ShipAddress = user.ShipAddress;

            ViewBag.Shippers = new SelectList(sr.SelectAll(), "Id", "CompanyName");

            return View(model);
        }

        public ActionResult OrderCompleted(int ShipperId)
        {
            var cart = (CartModel)Session["Cart"];
            if (cart == null) return RedirectToAction("TimeOut");

            var order = new Order();
            order.ShipperId = ShipperId;
            order.UserId = ur.SelectAll().FirstOrDefault(i => i.Username == User.Identity.Name).Id;
            foreach (var item in cart.CartLine)
            {
                var orderDetail = new OrderDetail();
                orderDetail.ProductId = item.ProductId;
                orderDetail.Quantity = item.Quantity;
                orderDetail.UnitPrice = item.SubTotal;
                order.OrderDetails.Add(orderDetail);
            }
            if (or.AddOrUpdate(order))
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    var product = pr.SelectById(orderDetail.ProductId);
                    product.Stock -= Convert.ToInt16(orderDetail.Quantity);
                    pr.AddOrUpdate(product);
                }
                Session["Order"] = order;
                return RedirectToAction("OrderInfo");
            }
            return RedirectToAction("OrderNotCreated");
        }

        public ActionResult OrderInfo()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("ctecommerce@hotmail.com", "CT123456");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("ctecommerce@hotmail.com", "CosmeticTrade");
            mail.To.Add("ysevgiaslan@gmail.com");
            mail.Subject = "Order";
            mail.IsBodyHtml = true;
            mail.Body = _OrderMailHelper().PartialRenderToString();

            smtp.Send(mail);

            Session["Cart"] = new CartModel();

            object userEmail = ur.SelectAll().FirstOrDefault(i => i.Username == User.Identity.Name).Email;

            return View(userEmail);
        }
        public ActionResult OrderNotCreated()
        {
            return View();
        }

        public PartialViewResult _OrderMailHelper()
        {
            return PartialView("_OrderMailHelper");
        }
    }
}