using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class Order : BaseEntity
    {
        public Order()
        {
            Random rastgele = new Random();
            this.OrderNumber = rastgele.Next(10000, 99999).ToString();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.OrderStatus = false;
        }

        [MaxLength(6)]
        public string OrderNumber { get; set; }
                
        [Required]
        public int ShipperId { get; set; }
        public virtual Shipper Shipper { get; set; }
        public bool OrderStatus { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
