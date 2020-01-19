using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Entity
{
    public class Category : BaseEntity
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }
        [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        [Required(ErrorMessage = "Category name cannot be empty.")]
        public string Name { get; set; }

        //[MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        [Required(ErrorMessage = "Description  cannot be empty.")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
