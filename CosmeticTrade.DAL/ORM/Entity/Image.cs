using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class Image : BaseEntity
    {
        [MaxLength(300,ErrorMessage = "Image name cannot exceed 300 characters")]
        [Required]
        public string ImageUrl { get; set; }

        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
