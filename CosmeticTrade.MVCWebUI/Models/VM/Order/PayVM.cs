using CosmeticTrade.DAL.ORM.Entity;
using CosmeticTrade.MVCWebUI.Models.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticTrade.MVCWebUI.Models.VM.Order
{
    public class PayVM
    {
        public CartModel Cart { get; set; }
        public string ShipAddress { get; set; }

        public int ShipperId { get; set; }
    }
}