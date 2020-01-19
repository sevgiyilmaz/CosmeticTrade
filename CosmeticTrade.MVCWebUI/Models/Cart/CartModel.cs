using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CosmeticTrade.MVCWebUI.Models.Cart
{
    public class CartModel
    {
        public int CardId { get; set; }
        private List<CartItemModel> _cart = new List<CartItemModel>();
        public List<CartItemModel> CartLine { get { return _cart; } }       
        public void Add(CartItemModel item)
        {
            if (_cart.Any(i=>i.ProductId==item.ProductId))
            {
                _cart.First(i => i.ProductId == item.ProductId).Quantity += 1;
                return;
            }
            _cart.Add(item);
        }      
        public void Remove(int id)
        {
            if (_cart.Any(i=>i.ProductId==id))
            {
                var item = _cart.FirstOrDefault(i => i.ProductId == id);
                _cart.Remove(item);
            }
        }
        public decimal Total()
        {
            return _cart.Sum(i => i.SubTotal);
        }
        public int Adet()
        {
            return _cart.Sum(i => i.Quantity);
        }
    }
          
    public class CartItemModel 
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
        public decimal SubTotal { get { return Price * Quantity; } }
    }
}