using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class Shipper:BaseEntity
    {
        public Shipper()
        {
            this.Orders = new HashSet<Order>();
        }

        [MaxLength(50, ErrorMessage = " CompanyName cannot exceed 50 characters.")]
        [Required(ErrorMessage = "CompanyName cannot be empty.")]
        public string CompanyName { get; set; }

        [MaxLength(20, ErrorMessage = "Phone cannot exceed 20 characters.")]
        [Phone]
        [Required(ErrorMessage = "Phone cannot be empty.")]        
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
