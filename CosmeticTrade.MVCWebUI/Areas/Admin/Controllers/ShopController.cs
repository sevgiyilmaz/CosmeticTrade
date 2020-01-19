using CosmeticTrade.BLL.Repositories.RepositoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CosmeticTrade.MVCWebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ShopController : Controller
    {
        OrderRepository or = new OrderRepository();
        OrderDetailRepository odr = new OrderDetailRepository();
        // GET: Admin/Shop
        public ActionResult List()
        {
            var list = or.SelectAll();
            list.Reverse();
            return View(list);
        }

        public ActionResult Detail(int id)
        {
            var od = or.SelectById(id);
            if (od != null)
            {
                return View(od);
            }
            return RedirectToAction("List");
        }
        public ActionResult OrderStatus(int id)
        {
            var order = or.SelectById(id);
            if (order != null)
            {
                order.OrderStatus = true;
                or.AddOrUpdate(order);
            }
            return RedirectToAction("List");
        }
    }
}