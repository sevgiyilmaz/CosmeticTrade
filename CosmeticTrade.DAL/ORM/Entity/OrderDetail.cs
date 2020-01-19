using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class OrderDetail:BaseEntity
    {
       
        [Required(ErrorMessage = "Quantity cannot be empty.")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "UnitPrice cannot be empty.")]
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }        

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
